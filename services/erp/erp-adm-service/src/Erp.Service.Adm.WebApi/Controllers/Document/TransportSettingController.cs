
namespace Erp.Service.Adm.WebApi;
[ApiController]
[Route("api/[controller]/[action]")]
public class TransportSettingController : BaseController
{
    [Authorize(AdmPermissionCode.TransportSettingView)]
    [HttpGet]
    public async Task<IActionResult> GetAsync(
       [FromQuery] TransportSettingGetQuery query,
       CancellationToken cancellationToken)
       => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingView)]
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportSettingGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingView)]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportSettingGetBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
       [FromBody] TransportSettingCreateCommand command,
       CancellationToken cancellationToken)
       => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportSettingUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingEdit)]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] TransportSettingAcceptCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingEdit)]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] TransportSettingCancelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TransportSettingDelete)]
    [HttpPost]
    public async Task<IActionResult> Delete(
        [FromBody] TransportSettingDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new TransportSettingFileUploadCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] TransportSettingFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

}
