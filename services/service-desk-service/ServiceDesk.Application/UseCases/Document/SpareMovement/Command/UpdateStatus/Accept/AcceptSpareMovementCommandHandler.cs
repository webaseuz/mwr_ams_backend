using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Constants;
using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class AcceptSpareMovementCommandHandler :
    IRequestHandler<AcceptSpareMovementCommand, IHaveId<long>>
{
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly ISpareTurnoverService _spareTurnoverService;

    public AcceptSpareMovementCommandHandler(
        IDocumentHistoryService documentHistoryService,
        IStorageAsyncService storageAsyncService,
        IWriteEfCoreContext context,
        IMapProvider mapper,
        ISpareTurnoverService spareTurnoverService)
    {
        _documentHistoryService = documentHistoryService;
        _storageAsyncService = storageAsyncService;
        _context = context;
        _mapper = mapper;
        _spareTurnoverService = spareTurnoverService;
    }

    public async Task<IHaveId<long>> Handle(
        AcceptSpareMovementCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var document = await _context.SpareMovements
             .Include(sm => sm.Tables)
             .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Accept();

            await AddToTurnover(document, cancellationToken);

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

    public async Task AddToTurnover(SpareMovement document,
                                    CancellationToken cancellationToken)
    {
        try
        {
            await _spareTurnoverService.InsertSpareTurnoverRow(
            new SpareTurnoverParameter(
            docNumber: document.DocNumber,
                                docDate: document.DocDate,
                                tableId: TableIdConst.DOC_SPARE_MOVEMENT,
                                documentId: document.Id,
                                movementTypeId: document.MovementTypeId,
                                fromBranchId: document.FromBranchId,
                                toBranchId: document.ToBranchId,
                                fromUserId: document.FromUserId,
                                toUserId: document.ToUserId,
                                tables: document.Tables
                                .Where(t => t.Quantity > 0)
                                .Select(d => new SpareTurnoverParameterTable
                                {
                                    DeviceSpareTypeId = d.DeviceSpareTypeId,
                                    DocumentTableId = d.Id,
                                    Quantity = d.Quantity
                                }).ToList()
                         ), cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
