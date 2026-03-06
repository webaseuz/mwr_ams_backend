
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.FuelTypeView)]
[ApiController]
[Route("[controller]/[action]")]
public class FuelTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] FuelTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] FuelTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] FuelTypeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AutoparkPermissionCode.FuelTypeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] FuelTypeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AutoparkPermissionCode.FuelTypeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] FuelTypeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.FuelTypeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] FuelTypeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}



