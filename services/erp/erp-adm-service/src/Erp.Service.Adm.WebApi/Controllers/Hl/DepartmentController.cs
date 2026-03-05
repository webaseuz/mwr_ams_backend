
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.DepartmentView)]
[ApiController]
[Route("[controller]/[action]")]
public class DepartmentController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] DepartmentGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] DepartmentGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] DepartmentGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.DepartmentCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] DepartmentCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.DepartmentEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] DepartmentUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.DepartmentDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DepartmentDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
