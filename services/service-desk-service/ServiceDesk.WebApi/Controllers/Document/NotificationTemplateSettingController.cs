using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.NotificationTemplateSettings;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ServiceDesk.WebApi.Controllers;

[Authorize(nameof(PermissionCode.NotificationTemplateSettingView))]
[ApiController]
[Route("[controller]/[action]")]
public class NotificationTemplateSettingController : MediatorController
{
    [HttpGet]
	public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetNotificationTemplateSettingBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetNotificationTemplateSettingQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetNotificationTemplateSettingByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.NotificationTemplateSettingCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.NotificationTemplateSettingEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.NotificationTemplateSettingAccept))]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.NotificationTemplateSettingCancel))]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.NotificationTemplateSettingDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
