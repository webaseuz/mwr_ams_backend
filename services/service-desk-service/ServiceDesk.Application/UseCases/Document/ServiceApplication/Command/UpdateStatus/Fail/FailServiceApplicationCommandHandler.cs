using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Application.Security;
using ServiceDesk.Application.UseCases.NotificationServices;
using ServiceDesk.Application.UseCases.Services.HistoryService;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class FailServiceApplicationCommandHandler :
    IRequestHandler<FailServiceApplicationCommand, IHaveId<long>>
{
    private readonly IMapProvider _mapper;
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    private readonly INotificationService _notificationService;
    private readonly IStorageAsyncService _storageAsyncService;
    private readonly IDocumentHistoryService _documentHistoryService;
    public FailServiceApplicationCommandHandler(
        IWriteEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        INotificationService notificationService,
        IStorageAsyncService storageAsyncService,
        IDocumentHistoryService documentHistoryService
        )
    {
        _mapper = mapper;
        _context = context;
        _authService = authService;
        _notificationService = notificationService;
        _storageAsyncService = storageAsyncService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        FailServiceApplicationCommand request,
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

            document.Fail();

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<ServiceApplication, ServiceApplicationDto>(_context.ServiceApplications)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, ServiceApplication, ServiceApplicationDto>(entityById, cancellationToken);

                await _storageAsyncService.MoveToPersistentAsync(document: FileStorageConst.SERVICE_APPLICATION_HISTORY,
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
                    .FirstOrDefaultAsync(x => x.Key == NotificationTemplateConst.DOCUMENT_FAILED, cancellationToken);

                if (testTemplate is null)
                    throw ClientLogicalExceptionHelper.NotificationTemplateNotFound(NotificationTemplateConst.DOCUMENT_FAILED);

                var userInfo = await _authService.GetUserAsync();
                var message = _notificationService.GenerateMessageFromTemplate<StatusTemplateDto>(testTemplate,
                                new StatusTemplateDto(document.DocNumber,
                                                    document.GetType().Name,
                                                    userInfo.UserName,
                                                    document.Branch.FullName,
                                                    "Muvofaqiyatsiz"));
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
