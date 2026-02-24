using AutoPark.Application.Security;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Transports;

public class UpdateTransportCommandHandler :
    IRequestHandler<UpdateTransportCommand, IHaveId<int>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IAsyncAppAuthService _authService;
    public UpdateTransportCommandHandler(
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
        UpdateTransportCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var userInfo = await _authService.GetUserAsync();
            if (!await _authService.HasPermissionAsync(PermissionCode.TransportCreateForAllBranch) && userInfo.BranchId != request.BranchId)
                request.BranchId = userInfo.BranchId.Value;

            var entity = await _context.Transports
                    .Include(x => x.Files)
                    .IsSoftActive()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

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
            entity.Files.UpdateFromFiles(document: FileStorageConst.TRANSPORT_FILE,
                                         documentId: entity.Id.ToString(),
                                         files: request.Files.Select(x => x.Id).ToList(),
                                         context: _context);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.TRANSPORT_FILE,
                                                               documentId: request.Id.ToString());

            request.UpdateEntity(entity, _mapper);

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync();

            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
