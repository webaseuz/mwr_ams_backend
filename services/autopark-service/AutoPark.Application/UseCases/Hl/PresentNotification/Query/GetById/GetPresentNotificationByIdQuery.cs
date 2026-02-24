using MediatR;

namespace AutoPark.Application.UseCases.PresentNotifications;

public class GetPresentNotificationByIdQuery :
    IRequest<PresentNotificationDto>
{
    public long Id { get; set; }
}
