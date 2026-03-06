
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.NotificationView)]
[ApiController]
[Route("[controller]/[action]")]
public class NotificationController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetUnreadNotificationAsync(
        [FromQuery] NotificationGetUnreadCountQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.AllNotificationView)]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] NotificationGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] NotificationGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByUserAsync(
        [FromQuery] NotificationGetByUserQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
