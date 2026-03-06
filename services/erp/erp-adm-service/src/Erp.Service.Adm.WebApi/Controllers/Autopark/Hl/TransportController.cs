
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.TransportView)]
[ApiController]
[Route("[controller]/[action]")]
public class TransportController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TransportGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TransportCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TransportDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new TransportFileUploadCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] TransportFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
