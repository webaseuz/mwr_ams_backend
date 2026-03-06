
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.PresentTrackingInfoView)]
[ApiController]
[Route("[controller]/[action]")]
public class TrackingInfoController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] TrackingInfoGetListQuery query,
    CancellationToken cancellationToken)
    {
        var stream = Mediator.CreateStream(query, cancellationToken);
        var list = new List<List<TrackingInfoBriefDto>>();

        await foreach (var group in stream.WithCancellation(cancellationToken))
            list.AddRange(group);

        return Ok(list);
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TrackingInfoGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TrackingInfoGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetDriverAndTransportInfoAsync(
        [FromQuery] TrackingInfoGetDriverAndTransportInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
