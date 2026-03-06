
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.NationalityView)]
[ApiController]
[Route("[controller]/[action]")]
public class NationalityController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] NationalityGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] NationalityGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] NationalityGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.NationalityCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] NationalityCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.NationalityEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] NationalityUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.NationalityDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] NationalityDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
