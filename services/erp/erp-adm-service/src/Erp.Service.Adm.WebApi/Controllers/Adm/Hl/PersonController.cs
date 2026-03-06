
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.PersonView)]
[ApiController]
[Route("[controller]/[action]")]
public class PersonController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] PersonGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] PersonGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] PersonGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByPinflAsync(
        [FromQuery] PersonGetByPassportDataQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    // [Authorize(AdmPermissionCode.PersonCreate)]
    // [HttpPost]
    // public async Task<IActionResult> CreateAsync(
    //     [FromBody] CreatePersonCommand command,
    //     CancellationToken cancellationToken)
    //     => Ok(await Mediator.Send(command, cancellationToken));

    // [Authorize(AdmPermissionCode.PersonEdit)]
    // [HttpPost]
    // public async Task<IActionResult> UpdateAsync(
    //     [FromBody] UpdatePersonCommand command,
    //     CancellationToken cancellationToken)
    //     => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.PersonDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] PersonDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFileAsync(
        [FromBody] PersonUploadPhotoCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    // [HttpPost]
    // public async Task<IActionResult> DownloadFileAsync(
    //     [FromBody] DownloadPersonFileCommand command,
    //     CancellationToken cancellationToken)
    //     => Ok(await Mediator.Send(command, cancellationToken));
}
