
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.BranchView)]
[ApiController]
[Route("[controller]/[action]")]
public class BranchController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] BranchGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] BranchGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] BranchGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.BranchCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] BranchCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.BranchEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] BranchUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.BranchDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] BranchDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
