
namespace Erp.Service.Adm.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class DashboardController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetDashboardAsync(
        [FromQuery] DashboardGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

}
