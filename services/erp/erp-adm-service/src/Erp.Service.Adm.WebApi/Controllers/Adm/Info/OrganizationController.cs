
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.OrganizationView)]
[ApiController]
[Route("[controller]/[action]")]
public class OrganizationController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] OrganizationGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] OrganizationGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.OrganizationAllView)]
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] OrganizationGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.OrganizationCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] OrganizationCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.OrganizationEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] OrganizationUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.OrganizationDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] OrganizationDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
