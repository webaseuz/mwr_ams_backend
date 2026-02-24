using AutoPark.Application.UseCases.Services.OptimalRouteService;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Security;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExternalOptimalRouteController : MediatorController
{
    [BasicAuth(realm: "autopark")]
    [HttpPost]
    public async Task<IActionResult> GetOptimalRoute([FromBody] OptimalRouteQuery query,
                                                     CancellationToken cancellationToken)
   => Ok(await Mediator.Send(query, cancellationToken));
}
