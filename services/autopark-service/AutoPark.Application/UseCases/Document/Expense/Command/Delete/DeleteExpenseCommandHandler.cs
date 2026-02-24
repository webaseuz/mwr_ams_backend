using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class DeleteExpenseCommandHandler :
    IRequestHandler<DeleteExpenseCommand, SuccessResult<bool>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IMapProvider _mapper;
    public DeleteExpenseCommandHandler(IWriteEfCoreContext context,
                                       IStorageAsyncService storageAsyncService,
                                       IDocumentHistoryService documentHistoryService,
                                       IMapProvider mapper)
    {
        _context = context;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
        _mapper = mapper;
    }

    public async Task<SuccessResult<bool>> Handle(
        DeleteExpenseCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _context.Expenses
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (entity == null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.Delete();

            try
            {
                var entityById = await _mapper.MapCollection<Expense, ExpenseDto>(_context.Expenses)
                    .FirstOrDefaultAsync(r => r.Id == entity.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Expense, ExpenseDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.EXPENSE_HISTORY,
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
