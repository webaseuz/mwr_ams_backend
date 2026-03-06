
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.MobileAppVersionView)]
[ApiController]
[Route("[controller]/[action]")]
public class MobileAppVersionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] MobileAppVersionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] MobileAppVersionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetLastVersionAsync(
        [FromQuery] MobileAppVersionGetLastQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.MobileAppVersionCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] MobileAppVersionCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.MobileAppVersionEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateStateAsync(
        [FromBody] MobileAppVersionUpdateStateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.MobileAppVersionDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] MobileAppVersionDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new MobileAppVersionFileUploadCommand { Files = files }, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] MobileAppVersionFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
