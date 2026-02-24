using MediatR;

namespace ServiceDesk.Application.UseCases.Notifications;

public class GetNotificationByIdQuery :
    IRequest<NotificationDto>
{
    public long Id { get; set; }
}
