using AutoPark.Application;
using AutoPark.Application.UseCases.DriverPenalties;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.DriverPenaltyView),
           nameof(PermissionCode.DriverPenaltyBranchView),
          nameof(PermissionCode.DriverPenaltyAllView))]
[ApiController]
[Route("[controller]/[action]")]
public class DriverPenaltyController : MediatorController
{
    [Authorize(nameof(PermissionCode.DriverPenaltyPay))]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetDriverPenaltyBriefAsPagedResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetDriverPenaltyByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
