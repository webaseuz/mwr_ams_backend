using MediatR;

namespace ServiceDesk.Application.UseCases.Notifications;

public class GetUnreadNotificationCountQuery :
    IRequest<int>
{
}
