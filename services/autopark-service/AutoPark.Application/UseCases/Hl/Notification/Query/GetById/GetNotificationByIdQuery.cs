using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetNotificationByIdQuery :
    IRequest<NotificationDto>
{
    public long Id { get; set; }
}
