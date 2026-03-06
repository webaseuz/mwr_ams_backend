
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.TransportBrandView)]
[ApiController]
[Route("[controller]/[action]")]
public class TransportBrandController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] TransportBrandGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] TransportBrandGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] TransportBrandGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AutoparkPermissionCode.TransportBrandCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] TransportBrandCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AutoparkPermissionCode.TransportBrandEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] TransportBrandUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.TransportBrandDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] TransportBrandDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
