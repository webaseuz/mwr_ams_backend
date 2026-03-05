
using Erp.Service.Adm.Application.UseCases;

namespace Erp.Service.Adm.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OptimalRouteController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> GetOptimalRoute([FromBody] OptimalRouteQuery query,
                                                     CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));
}
