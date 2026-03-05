
using Erp.Service.Adm.Application.UseCases;

namespace Erp.Service.Adm.WebApi;

[ApiController]
[Route("[controller]/[action]")]
public class ExternalOptimalRouteController : BaseController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> GetOptimalRoute([FromBody] OptimalRouteQuery query,
                                                     CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));
}
