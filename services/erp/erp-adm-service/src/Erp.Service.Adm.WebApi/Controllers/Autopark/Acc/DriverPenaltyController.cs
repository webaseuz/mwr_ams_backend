
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.DriverPenaltyView, AutoparkPermissionCode.DriverPenaltyBranchView, AutoparkPermissionCode.DriverPenaltyAllView)]
[ApiController]
[Route("[controller]/[action]")]
public class DriverPenaltyController : BaseController
{
    [Authorize(AutoparkPermissionCode.DriverPenaltyPay)]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] DriverPenaltyGetListQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] DriverPenaltyGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
