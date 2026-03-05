
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.PositionView)]
[ApiController]
[Route("[controller]/[action]")]
public class PositionController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] PositionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] PositionGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] PositionGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AdmPermissionCode.PositionCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] PositionCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.PositionEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] PositionUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.PositionDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] PositionDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
