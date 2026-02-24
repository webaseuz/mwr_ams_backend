using AutoPark.Application.UseCases.Banks;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DashboardController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetDashboardAsync(
        [FromQuery] GetDashboardQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

}
