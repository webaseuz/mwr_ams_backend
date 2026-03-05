
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.RefuelView)]
[ApiController]
[Route("[controller]/[action]")]
public class RefuelController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] RefuelGetBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] RefuelGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] RefuelGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] RefuelCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] RefuelUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelAccept)]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] RefuelAcceptCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelSend)]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] RefuelSendCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelRevoke)]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] RefuelRevokeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelCancel)]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] RefuelCancelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RefuelDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] RefuelDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new RefuelFileUploadCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] RefuelFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
