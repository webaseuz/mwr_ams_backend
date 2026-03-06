
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.TransportUseTypeView)]
[ApiController]
[Route("[controller]/[action]")]
public class TransportUseTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportUseTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TransportUseTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportUseTypeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportUseTypeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TransportUseTypeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportUseTypeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportUseTypeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportUseTypeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TransportUseTypeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
