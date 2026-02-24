using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class CreateTransportCommandHandler :
    IRequestHandler<CreateTransportCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    public CreateTransportCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _authService = authService;
    }

    public async Task<IHaveId<int>> Handle(
        CreateTransportCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var userInfo = await _authService.GetUserAsync();
            if (!await _authService.HasPermissionAsync(PermissionCode.TransportCreateForAllBranch) && userInfo.BranchId.Value != request.BranchId)
                request.BranchId = userInfo.BranchId.Value;

            var stateNumber = _context.Set<Transport>()
                .Where(x => x.StateNumber == request.StateNumber && x.StateId == StateIdConst.ACTIVE)
                .FirstOrDefault();

            if (stateNumber != null)
            {
                throw new Exception($"{request.StateNumber} Государственный цифровой транспорт уже существует");
            }

            var vinNumber = _context.Set<Transport>()
               .Where(x => x.VinNumber == request.VinNumber && x.StateId == StateIdConst.ACTIVE)
               .FirstOrDefault();

            if (vinNumber != null)
            {
                throw new Exception($"{request.VinNumber} вин цифровой транспорт уже доступен");
            }

            var entity = request.CreateEntity<CreateTransportCommand, Transport>(_mapper);

            entity.UniqueCode = Guid.NewGuid();
            entity.MarkAsActive();



            entity.Files.AddFromTempFiles(document: FileStorageConst.TRANSPORT_FILE,
                                              tempFileIds: request.Files.Select(x => x.Id).ToList());
            //var result = await _context.CreateAndSaveAsync<int, Transport>(entity, cancellationToken);

            var result = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            if (request.Files.Any())
                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.TRANSPORT_FILE,
                                                                 documentId: entity.Id.ToString(),
                                                                 tempFileIds: request.Files.Select(x => x.Id).ToArray());

            await transaction.CommitAsync(cancellationToken);

            return HaveId.Create(entity.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
