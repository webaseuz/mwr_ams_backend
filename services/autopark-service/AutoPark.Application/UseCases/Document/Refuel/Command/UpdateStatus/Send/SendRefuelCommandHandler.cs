using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Refuels;

public class SendRefuelCommandHandler :
    IRequestHandler<SendRefuelCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    public SendRefuelCommandHandler(IWriteEfCoreContext context,
                                    IMapProvider mapper,
                                    IDocumentHistoryService documentHistoryService,
                                    IStorageAsyncService storageAsyncService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        SendRefuelCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.Refuels
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Send();

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<Refuel, RefuelDto>(_context.Refuels)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Refuel, RefuelDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.REFUEL_HISTORY,
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
}
