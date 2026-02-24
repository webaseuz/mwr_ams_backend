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

public class DeleteRefuelCommandHandler :
    IRequestHandler<DeleteRefuelCommand, SuccessResult<bool>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    public DeleteRefuelCommandHandler(IWriteEfCoreContext context,
                                      IMapProvider mapper,
                                      IStorageAsyncService storageAsyncService,
                                      IDocumentHistoryService documentHistoryService)
    {
        _context = context;
        _mapper = mapper;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteRefuelCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.Refuels
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.Delete();

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
            return SuccessResult.Create(true);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
