using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Notifications;

public class GetNotificationByIdQueryHandler :
    IRequestHandler<GetNotificationByIdQuery, NotificationDto>
{
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    private readonly IWriteEfCoreContext _writeContext;

    public GetNotificationByIdQueryHandler(
        IMapProvider mapper,
        IAsyncAppAuthService authService,
        IWriteEfCoreContext writeContext)
    {
        _mapper = mapper;
        _writeContext = writeContext;
        _authService = authService;
    }

    public async Task<NotificationDto> Handle(
		GetNotificationByIdQuery request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _writeContext.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            var entity = await _writeContext.Notifications
            .FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            if (entity is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            entity.IsRead = true;
            entity.ReadAt = DateTime.Now;
            await _writeContext.SaveChangesAsync(cancellationToken);
            var dto = _mapper.Map<Notification, NotificationDto>(entity);

            if (dto is null)
                throw ClientLogicalExceptionHelper.NotFound(request.Id);

            await transaction.CommitAsync(cancellationToken);
            return dto;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

}