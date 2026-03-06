
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.TransportTypeView)]
[ApiController]
[Route("[controller]/[action]")]
public class TransportTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TransportTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportTypeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportTypeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TransportTypeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportTypeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportTypeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportTypeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TransportTypeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
