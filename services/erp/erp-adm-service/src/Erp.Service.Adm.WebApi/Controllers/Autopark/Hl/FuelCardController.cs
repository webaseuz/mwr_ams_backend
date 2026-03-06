
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.FuelCardView)]
[ApiController]
[Route("[controller]/[action]")]
public class FuelCardController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] FuelCardGetListQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] FuelCardGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] FuelCardGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AutoparkPermissionCode.FuelCardCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] FuelCardCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AutoparkPermissionCode.FuelCardEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] FuelCardUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.FuelCardDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] FuelCardDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
