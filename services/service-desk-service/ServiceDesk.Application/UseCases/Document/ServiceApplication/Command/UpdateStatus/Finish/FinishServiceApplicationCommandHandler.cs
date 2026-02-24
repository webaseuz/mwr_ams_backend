using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.NotificationServices;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class FinishServiceApplicationCommandHandler :
    IRequestHandler<FinishServiceApplicationCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly INotificationService _notificationService;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly ISpareTurnoverService _spareTurnoverService;

    public FinishServiceApplicationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService,
        ISpareTurnoverService spareTurnoverService,
        INotificationService notificationService,
        IAsyncAppAuthService authService
        )
    {
        _mapper = mapper;
        _context = context;
        _authService = authService;
        _notificationService = notificationService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
        _spareTurnoverService = spareTurnoverService;
    }

    public async Task<IHaveId<long>> Handle(
        FinishServiceApplicationCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var document = await _context.ServiceApplications
                .Include(x => x.Branch)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);
            var time = document.ModifiedAt;
            document.Finish();


            var documentHistory = await _context.ServiceApplicationHistories
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(x => x.OwnerId == document.Id && x.StatusId == StatusIdConst.SEND);

            var endAt = DateTime.Now;
            document.ProcessDuration = (endAt - documentHistory.CreatedAt).Minutes;
            document.EndAt = endAt;

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(_context.ServiceApplications)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, ServiceApplication, ServiceApplicationDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_HISTORY,
                                                                         documentId: document.Id.ToString(),
                                                                         tempFileIds: historyFileId);

                if (document.ExecutorTypeId == ExecutorTypeIdConst.INTERNAL_SERVICE)
                {
                    var entry = _context.Entry(document);
                    await entry.Collection(e => e.ServiceApplicationSpares).LoadAsync(cancellationToken);

                    if(document.ServiceApplicationSpares.Any())
                        await AddToTurnover(document, cancellationToken);
                }

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
                    .FirstOrDefaultAsync(x => x.Key == NotificationTemplateConst.DOCUMENT_FINISHED, cancellationToken);

                if (testTemplate is null)
                    throw ClientLogicalExceptionHelper.NotificationTemplateNotFound(NotificationTemplateConst.DOCUMENT_FINISHED);

                var userInfo = await _authService.GetUserAsync();
                var message = _notificationService.GenerateMessageFromTemplate<StatusTemplateDto>(testTemplate,
                                new StatusTemplateDto(document.DocNumber,
                                                    document.GetType().Name,
                                                    userInfo.UserName,
                                                    document.Branch.FullName,
                                                    "Tugallandi"));
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

            throw;
        }
        
    }


    public async Task AddToTurnover(ServiceApplication document,
                                    CancellationToken cancellationToken)
    {
        try
        {
            await _spareTurnoverService.InsertSpareTurnoverRow(
            new SpareTurnoverParameter(
            docNumber: document.DocNumber,
                                docDate: document.DocDate,
                                tableId: TableIdConst.DOC_SERVICE_APPLICATION,
                                documentId: document.Id,
                                movementTypeId: MovementTypeIdConst.OUTCOME,
                                fromBranchId: document.BranchId,
                                tables: document.ServiceApplicationSpares
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
