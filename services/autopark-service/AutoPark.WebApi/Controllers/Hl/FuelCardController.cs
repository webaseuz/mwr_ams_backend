using AutoPark.Application;
using AutoPark.Application.UseCases.FuelCards;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.FuelCardView))]
[ApiController]
[Route("[controller]/[action]")]
public class FuelCardController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] GetFuelCardBriefPagedResultQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetFuelCardQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetFuelCardByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));


    [Authorize(nameof(PermissionCode.FuelCardCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateFuelCardCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));


    [Authorize(nameof(PermissionCode.FuelCardEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateFuelCardCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.FuelCardDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteFuelCardCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
