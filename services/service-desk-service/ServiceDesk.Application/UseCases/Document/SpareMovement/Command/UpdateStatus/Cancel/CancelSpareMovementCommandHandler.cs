using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Domain.Constants;
using ServiceDesk.Domain;
using ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CancelSpareMovementCommandHandler :
    IRequestHandler<CancelSpareMovementCommand, IHaveId<long>>
{
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly ISpareTurnoverService _spareTurnoverService;

    public CancelSpareMovementCommandHandler(
        IDocumentHistoryService documentHistoryService,
        IStorageAsyncService storageAsyncService,
        IWriteEfCoreContext context,
        IMapProvider mapper,
        ISpareTurnoverService spareTurnoverService
        )
    {
        _documentHistoryService = documentHistoryService;
        _storageAsyncService = storageAsyncService;
        _mapper = mapper;
        _spareTurnoverService = spareTurnoverService;
        _context = context;
    }
    public async Task<IHaveId<long>> Handle(
        CancelSpareMovementCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var document = await _context.SpareMovements
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Cancel();

            await RemoveFromTurnover(document.Id, cancellationToken);


            await _context.SaveChangesAsync(cancellationToken);
            try
            {
                var entityById = await _mapper.MapCollection<SpareMovement, SpareMovementDto>(_context.SpareMovements)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, SpareMovement, SpareMovementDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SPARE_MOVEMENT_HISTORY,
                                                                         documentId: document.Id.ToString(),
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



    public async Task RemoveFromTurnover(long documentId,
                                         CancellationToken cancellationToken)
    {
        try
        {
            await _spareTurnoverService.RemoveSpareTurnoverRow(
            new RemoveSpareTurnoverRowDto(
                tableId: TableIdConst.DOC_SPARE_MOVEMENT,
                documentId: documentId
                         ), cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
