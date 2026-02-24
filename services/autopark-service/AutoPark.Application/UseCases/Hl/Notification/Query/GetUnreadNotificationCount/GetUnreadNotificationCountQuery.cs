using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetUnreadNotificationCountQuery :
    IRequest<int>
{
}
