
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.DriverPenaltyView, AdmPermissionCode.DriverPenaltyBranchView, AdmPermissionCode.DriverPenaltyAllView)]
[ApiController]
[Route("[controller]/[action]")]
public class DriverPenaltyController : BaseController
{
    [Authorize(AdmPermissionCode.DriverPenaltyPay)]
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
