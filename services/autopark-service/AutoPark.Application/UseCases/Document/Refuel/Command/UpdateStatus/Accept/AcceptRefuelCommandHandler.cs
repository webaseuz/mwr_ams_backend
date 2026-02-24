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

namespace AutoPark.Application.UseCases.Refuels;

public class AcceptRefuelCommandHandler :
    IRequestHandler<AcceptRefuelCommand, IHaveId<long>>
{
    private readonly IWriteEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly IStorageAsyncService _storageAsync;
    private readonly IDocumentHistoryService _documentHistoryService;
    private readonly INotificationService _notificationService;
    public AcceptRefuelCommandHandler(IWriteEfCoreContext context,
                                      IAsyncAppAuthService authService,
                                      IMapProvider mapper,
                                      IStorageAsyncService storageAsync,
                                      IDocumentHistoryService documentHistoryService,
                                      INotificationService notificationService)
    {
        _mapper = mapper;
        _context = context;
        _authService = authService;
        _storageAsync = storageAsync;
        _notificationService = notificationService;
        _documentHistoryService = documentHistoryService;
    }

    public async Task<IHaveId<long>> Handle(
        AcceptRefuelCommand request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var document = await _context.Refuels
                .Include(x => x.Branch)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (document is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            document.Accept();

            await _context.SaveChangesAsync(cancellationToken);

            try
            {
                var entityById = await _mapper.MapCollection<Refuel, RefuelDto>(_context.Refuels)
                    .FirstOrDefaultAsync(r => r.Id == document.Id, cancellationToken);

                var historyFileId = await _documentHistoryService.AddHistory<long, Refuel, RefuelDto>(entityById, cancellationToken);

                await _storageAsync.MoveToPersistentAsync(document: FileStorageConst.REFUEL_HISTORY,
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
