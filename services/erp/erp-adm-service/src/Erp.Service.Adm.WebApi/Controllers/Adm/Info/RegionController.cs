
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.OptimalRoute)]
[ApiController]
[Route("[controller]/[action]")]
public class RegionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] RegionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] RegionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] RegionGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.RegionCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] RegionCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.RegionEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] RegionUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.RegionDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] RegionDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
