
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.OilModelView)]
[ApiController]
[Route("[controller]/[action]")]
public class OilModelController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] OilModelGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] OilModelGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] OilModelGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.OilModelCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] OilModelCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.OilModelEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] OilModelUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.OilModelDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] OilModelDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
