using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.Notifications;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDesk.MobileApi.Controllers;

[Authorize(nameof(PermissionCode.NotificationView))]
[ApiController]
[Route("[controller]/[action]")]
public class NotificationController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetUnreadNotificationAsync(
        [FromQuery] GetUnreadNotificationCountQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetNotificationByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByUserAsync(
        [FromQuery] GetNotificationsByUserQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
