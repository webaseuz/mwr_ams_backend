using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Notifications;

public class CreateNotificationCommand :
    IRequest<SuccessResult<bool>>
{
}
