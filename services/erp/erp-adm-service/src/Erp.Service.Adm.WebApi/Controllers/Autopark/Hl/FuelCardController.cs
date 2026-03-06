
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.FuelCardView)]
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


    [Authorize(AdmPermissionCode.FuelCardCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] FuelCardCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AdmPermissionCode.FuelCardEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] FuelCardUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.FuelCardDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] FuelCardDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
