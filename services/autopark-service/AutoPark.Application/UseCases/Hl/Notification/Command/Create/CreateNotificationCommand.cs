using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class CreateNotificationCommand :
    IRequest<SuccessResult<bool>>
{
}
