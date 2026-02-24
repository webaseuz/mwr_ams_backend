using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
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

namespace AutoPark.Application.UseCases.Refuels;

public class UpdateRefuelCommandHandler :
    IRequestHandler<UpdateRefuelCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;

    public UpdateRefuelCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        UpdateRefuelCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            await ValidateUpdateRefuelCommand(request, cancellationToken);

            var entity = await _context.Refuels.Include(x => x.Files)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.Update();

            var userInfo = await _authService.GetUserAsync();
            if (!userInfo.Permissions.Contains(nameof(PermissionCode.RefuelCreateForAllBranch)) || !request.BranchId.HasValue)
                entity.BranchId = userInfo.BranchId;

            entity.Files.UpdateFromFiles(document: FileStorageConst.REFUEL_FILE,
                                         documentId: entity.Id.ToString(),
                                         files: request.Files.Select(x => x.Id).ToList(),
                                         context: _context);

            await _storageAsyncService.ResolveMarkedFilesAsync(document: FileStorageConst.REFUEL_FILE,
                                                               documentId: request.Id.ToString());

            request.UpdateEntity(entity, _mapper);

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<Refuel, RefuelDto>(_context.Refuels)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Refuel, RefuelDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.REFUEL_HISTORY,
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
    private async Task ValidateUpdateRefuelCommand(UpdateRefuelCommand request,
                                                   CancellationToken cancellationToken)
    {
        var hasInfo = await _context.FuelCards
            .IsSoftActive()
            .AnyAsync(fc => !fc.IsDeleted &&
                            fc.Id == request.FuelCardId &&
                            fc.TransportId == request.TransportId);

        if (!hasInfo)
            throw ClientLogicalExceptionHelper.InvalidFuelCard(request.TransportId);

    }
}
