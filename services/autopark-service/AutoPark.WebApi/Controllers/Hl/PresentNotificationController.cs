using AutoPark.Application;
using AutoPark.Application.UseCases.PresentNotifications;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.PresentNotificationView))]
[ApiController]
[Route("[controller]/[action]")]
public class PresentNotificationController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetPresentNotificationByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByUserAsync(
        [FromQuery] GetPresentNotificationsByUserQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
