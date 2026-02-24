using AutoPark.Application.UseCases.Services.OptimalRouteService;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class OptimalRouteController : MediatorController
{
    [HttpPost]
    public async Task<IActionResult> GetOptimalRoute([FromBody] OptimalRouteQuery query,
                                                     CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));
}
