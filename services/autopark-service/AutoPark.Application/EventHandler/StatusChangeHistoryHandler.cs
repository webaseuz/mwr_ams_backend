using AutoPark.Application.Security;
using AutoPark.Domain.Entities;
using Bms.Core.Application.Abstraction;
using Bms.Core.Domain.Events;
using Minio;

namespace AutoPark.Application.EventHandlers;

public class StatusChangeHistoryHandler<TId> :
    IEventHandler<StatusChangedEvent<TId>, TId>
    where TId : struct
{
    private readonly IWriteEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public StatusChangeHistoryHandler(
        IWriteEfCoreContext context,
        IAsyncAppAuthService authService,
        IMinioClient minioClient)
    {
        _context = context;
        _authService = authService;
    }

    public async Task Handle(StatusChangedEvent<TId> @event)
    {
        string userInfo = await _authService.GetUserIdentityAsync();

        Guid historyFileId = Guid.NewGuid();

        /*
            Bu yerda minio ga DataAsJson ni saqlanadi
         
         */

        var history = new HistoryEntity<TId>()
        {
            OwnerId = @event.OwnerId,
            Message = @event.Message,
            StatusId = @event.StatusId,
            DataJson = @event.DataAsJson,
            UserInfo = userInfo,
            HistoryFileId = historyFileId
        };

        await _context.AddAsync(history);
    }
}