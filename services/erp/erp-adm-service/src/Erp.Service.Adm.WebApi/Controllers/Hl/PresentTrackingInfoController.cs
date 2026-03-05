
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.PresentTrackingInfoView)]
[ApiController]
[Route("[controller]/[action]")]
public class PresentTrackingInfoController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] PresentTrackingInfoGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] PresentTrackingInfoGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] PresentTrackingInfoGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetDriverAndTransportInfoAsync(
        [FromQuery] TrackingInfoGetDriverAndTransportInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.PresentTrackingInfoCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromBody] PresentTrackingInfoCreateCommand command,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(command, cancellationToken));
}
