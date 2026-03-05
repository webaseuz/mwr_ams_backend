
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.PresentNotificationView)]
[ApiController]
[Route("[controller]/[action]")]
public class PresentNotificationController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] PresentNotificationGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByUserAsync(
        [FromQuery] PresentNotificationGetByUserQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
