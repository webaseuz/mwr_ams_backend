
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.RoleView)]
[ApiController]
[Route("[controller]/[action]")]
public class RoleController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] RoleGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] RoleGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] RoleGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.RoleCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] RoleCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RoleEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] RoleUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RoleDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] RoleDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}