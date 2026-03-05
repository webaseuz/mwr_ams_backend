
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.TireModelView)]
[ApiController]
[Route("[controller]/[action]")]
public class TireModelController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TireModelGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TireModelGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TireModelGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.TireModelCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TireModelCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TireModelEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TireModelUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TireModelDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TireModelDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
