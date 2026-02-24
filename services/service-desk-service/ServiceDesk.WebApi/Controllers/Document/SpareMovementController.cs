using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.SpareMovements;

namespace ServiceDesk.WebApi.Controllers;

[Authorize(nameof(PermissionCode.SpareMovementView))]
[ApiController]
[Route("[controller]/[action]")]
public class SpareMovementController : MediatorController
{
    [HttpGet]
    [Authorize(nameof(PermissionCode.SpareMovementView), nameof(PermissionCode.SpareMovementAllView))]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetSpareMovementBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetSpareMovementQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetSpareMovementByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceTypeCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceTypeEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationAccept))]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationSend))]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] SendSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationRevoke))]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] RevokeSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationCancel))]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteSpareMovementCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
