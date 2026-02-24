using AutoPark.Application.Security;
using AutoPark.Application.UseCases.HistoryServices;
using AutoPark.Application.UseCases.NotificationServices;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Expenses;

public class AcceptExpenseCommandHandler :
    IRequestHandler<AcceptExpenseCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly INotificationService _notificationService;
    public AcceptExpenseCommandHandler(IWriteEfCoreContext context,
                                       IStorageAsyncService storageAsyncService,
                                       IDocumentHistoryService documentHistoryService,
                                       IMapProvider mapper,
                                       IAsyncAppAuthService authService,
                                       INotificationService notificationService)
    {
        _context = context;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
        _mapper = mapper;
        _authService = authService;
        _notificationService = notificationService;
    }
    public async Task<IHaveId<long>> Handle(
        AcceptExpenseCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.Expenses
                .Include(x => x.Branch)
                .Include(x => x.Batteries)
                .Include(x => x.Insurances)
                .Include(x => x.Inspections)
                .Include(x => x.Liquids)
                .Include(x => x.Oils)
                .Include(x => x.Tires)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            if (document.Batteries.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Batteries.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Batteries), ids);
            }
            else if (document.Insurances.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Insurances.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Insurances), ids);
            }
            else if (document.Inspections.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Inspections.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Inspections), ids);
            }
            else if (document.Liquids.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Liquids.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Liquids), ids);
            }
            else if (document.Oils.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Oils.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Oils), ids);
            }
            else if (document.Tires.Any(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false))
            {
                var ids = document.Tires.Where(x => x.InvoiceNumber.IsNullOrEmptyObject() && x.IsDeleted == false).Select(x => x.Id).ToArray();
                throw ClientLogicalExceptionHelper.NotFountInvoiceNumber(nameof(document.Tires), ids);
            }

            document.Accept();

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
                    .FirstOrDefaultAsync(x => x.Key == NotificationTemplateConst.DOCUMENT_ACCEPTED, cancellationToken);

                if (testTemplate is null)
                    throw ClientLogicalExceptionHelper.NotificationTemplateNotFound(NotificationTemplateConst.DOCUMENT_ACCEPTED);

                var userInfo = await _authService.GetUserAsync();
                var message = _notificationService.GenerateMessageFromTemplate<StatusTemplateDto>(testTemplate,
                                new StatusTemplateDto(document.DocNumber,
                                                    document.GetType().Name,
                                                    userInfo.UserName,
                                                    document.Branch.FullName,
                                                    "Accepted"));
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
