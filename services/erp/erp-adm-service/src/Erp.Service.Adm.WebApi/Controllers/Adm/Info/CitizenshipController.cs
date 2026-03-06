
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.CitizenshipView)]
[ApiController]
[Route("[controller]/[action]")]
public class CitizenshipController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] CitizenshipGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] CitizenshipGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] CitizenshipGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.CitizenshipCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CitizenshipCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.CitizenshipEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] CitizenshipUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.CitizenshipDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] CitizenshipDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
