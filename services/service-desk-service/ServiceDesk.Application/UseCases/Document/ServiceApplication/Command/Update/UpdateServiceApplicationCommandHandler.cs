using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.MinioSdk;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UpdateServiceApplicationCommandHandler :
    IRequestHandler<UpdateServiceApplicationCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _readEfCoreContext;

    public UpdateServiceApplicationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService,
        IAsyncAppAuthService authService,
        IDocumentHistoryService documentHistoryService,
        IReadEfCoreContext readEfCoreContext)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
        _readEfCoreContext = readEfCoreContext;
    }

    public async Task<IHaveId<long>> Handle(
        UpdateServiceApplicationCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var entity = await _context.ServiceApplications
                .Include(x => x.ServiceApplicationFiles)
                .Include(x => x.ServiceApplicationExecutorFiles)
                .Include(x => x.ServiceApplicationParts)
                .Include(x => x.ServiceApplicationSpares)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            var userInfo = await _authService.GetUserAsync();

            // ExecutorEdit qilgan xolat uchun
            if (userInfo.Permissions.Contains(nameof(PermissionCode.ServiceApplicationInProcess)) 
                    && (entity.StatusId == StatusIdConst.IN_PROCESS || entity.StatusId == StatusIdConst.CANCELED_BY_CLIENT))
            {
                if (entity.StatusId == StatusIdConst.IN_PROCESS)
                {
                    if (request.ExecutorTypeId == ExecutorTypeIdConst.INTERNAL_SERVICE)
                        await QuantityValidation(request);
                    
                    request.Spares.ApplyChangesTo<long, UpdateServiceApplicationSpareCommand, ServiceApplicationSpare>(entity.ServiceApplicationSpares, _mapper);

                }

                entity.ExecutorComment = request.ExecutorComment;

                entity.ServiceApplicationExecutorFiles.UpdateFromFiles(FileStorageConst.SERVICE_APPLICATION_FILE,
                                                                       entity.Id.ToString(),
                                                                       request.ExecutorFiles.Select(x => x.Id).ToList(),
                                                                       _context);
            }
            else
            {
                request.Parts.ApplyChangesTo<long, UpdateServiceApplicationPartCommand, ServiceApplicationPart>(entity.ServiceApplicationParts, _mapper);

                entity.Update();

                entity.ServiceApplicationFiles.UpdateFromFiles(document: FileStorageConst.SERVICE_APPLICATION_FILE,
                                             documentId: entity.Id.ToString(),
                                             files: request.Files.Select(x => x.Id).ToList(),
                                             context: _context);

                request.UpdateEntity(entity, _mapper);
            }

            await _context.SaveChangesAsync(cancellationToken);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.SERVICE_APPLICATION_FILE,
                                                               documentId: request.Id.ToString());

            try
            {
                var entityById = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(_context.ServiceApplications)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, ServiceApplication, ServiceApplicationDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_HISTORY,
                                                                         documentId: entity.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            await transaction.CommitAsync(cancellationToken);
            return HaveId.Create(request.Id);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

    }
    private async Task QuantityValidation(UpdateServiceApplicationCommand request)
    {
        foreach (var spare in request.Spares)
        {
            var presentSpareTurnover = await _readEfCoreContext.PresentSpareTurnovers
                                       .FirstOrDefaultAsync(x => x.BranchId == request.BranchId
                                       && x.DeviceSpareTypeId == spare.DeviceSpareTypeId);

            if (presentSpareTurnover == null)
                throw ClientLogicalExceptionHelper.NotEnaughQuantity($"{spare.DeviceSpareTypeId}",
                    $"{spare.Quantity}");

            if (presentSpareTurnover.Quantity < spare.Quantity)
                throw ClientLogicalExceptionHelper.NotEnaughQuantity($"{presentSpareTurnover.DeviceSpareType.FullName}",
                    $"{spare.Quantity - presentSpareTurnover.Quantity}");
        }
    }
}
