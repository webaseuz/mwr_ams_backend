using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Application.UseCases.NotificationServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class CancelExpenseCommandHandler :
    IRequestHandler<CancelExpenseCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly INotificationService _notificationService;
    private readonly IAsyncAppAuthService _authService;
    private readonly IMapProvider _mapper;
    public CancelExpenseCommandHandler(IWriteEfCoreContext context,
                                       IStorageAsyncService storageAsyncService,
                                       IDocumentHistoryService documentHistoryService,
                                       INotificationService notificationService,
                                       IAsyncAppAuthService authService,
                                       IMapProvider mapper)
    {
        _context = context;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
        _notificationService = notificationService;
        _authService = authService;
        _mapper = mapper;
    }
    public async Task<IHaveId<long>> Handle(
        CancelExpenseCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.Expenses
                .Include(x => x.Branch)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Cancel();

            try
            {
                var entityById = await _mapper.MapCollection<Expense, ExpenseDto>(_context.Expenses)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Expense, ExpenseDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.EXPENSE_HISTORY,
                                                                         documentId: document.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }

            #region Notification Part
            try
            {
                var testTemplate = await _context.NotificationTemplates
                    .FirstOrDefaultAsync(x => x.Key == NotificationTemplateConst.DOCUMENT_CANCELED, cancellationToken);

                if (testTemplate is null)
                    throw ClientLogicalExceptionHelper.NotificationTemplateNotFound(NotificationTemplateConst.DOCUMENT_CANCELED);

                var userInfo = await _authService.GetUserAsync();
                var res = new StatusTemplateDto(document.DocNumber,
                                                document.DocNumber,
                                                userInfo.UserName,
                                                document.Branch.FullName,
                                                "Canceled");

                var message = _notificationService.GenerateMessageFromTemplate<StatusTemplateDto>(testTemplate, res);

                var ntEntity = new Notification()
                {
                    Subject = "StatusChange",
                    Message = message,
                    UserId = document.CreatedBy.Value,
                    SentAt = DateTime.Now,
                    NotificationTemplateId = testTemplate.Id,
                };
                var succesResult = await _notificationService.AddNotificationAsync(ntEntity, cancellationToken);
                if (!succesResult)
                    throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }
            #endregion

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
