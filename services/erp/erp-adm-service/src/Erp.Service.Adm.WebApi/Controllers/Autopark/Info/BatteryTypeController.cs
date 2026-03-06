
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.BatteryTypeView)]
[ApiController]
[Route("[controller]/[action]")]
public class BatteryTypeController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
      [FromQuery] BatteryTypeGetListQuery query,
      CancellationToken cancellationToken)
      => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] BatteryTypeGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] BatteryTypeGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(AutoparkPermissionCode.BatteryTypeCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] BatteryTypeCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(AutoparkPermissionCode.BatteryTypeEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] BatteryTypeUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.BatteryTypeDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] BatteryTypeDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
