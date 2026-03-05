
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.NotificationTemplateSettingView)]
[ApiController]
[Route("[controller]/[action]")]
public class NotificationTemplateSettingController : BaseController
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

    [Authorize(AdmPermissionCode.NotificationTemplateSettingCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.NotificationTemplateSettingEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.NotificationTemplateSettingAccept)]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.NotificationTemplateSettingCancel)]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.NotificationTemplateSettingDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteNotificationTemplateSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
