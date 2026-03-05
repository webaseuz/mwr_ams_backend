
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.TireSizeView)]
[ApiController]
[Route("[controller]/[action]")]
public class TireSizeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TireSizeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TireSizeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TireSizeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AdmPermissionCode.TireSizeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TireSizeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TireSizeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TireSizeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.TireSizeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TireSizeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
