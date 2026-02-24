using AutoPark.Application;
using AutoPark.Application.UseCases.TransportTypes;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.TransportTypeView))]
[ApiController]
[Route("[controller]/[action]")]
public class TransportTypeController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetTransportTypeBriefPagedResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetTransportTypeQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetTransportTypeByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportTypeCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateTransportTypeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportTypeEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateTransportTypeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportTypeDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteTransportTypeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
