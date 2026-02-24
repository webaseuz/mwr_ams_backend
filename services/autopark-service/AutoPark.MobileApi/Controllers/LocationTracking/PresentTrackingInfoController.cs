using AutoPark.Application;
using AutoPark.Application.UseCases.PresentTrackingInfos;
using AutoPark.Application.UseCases.TrackingInfos;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PresentTrackingInfoController : MediatorController
{
    [Authorize(nameof(PermissionCode.PresentTrackingInfoView))]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] GetPresentTrackingInfoBriefPagedResultQuery query,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.PresentTrackingInfoView))]
    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetPresentTrackingInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
    [Authorize(nameof(PermissionCode.PresentTrackingInfoView))]
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetPresentTrackingInfoByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
    [Authorize(nameof(PermissionCode.PresentTrackingInfoView))]
    [HttpGet]
    public async Task<IActionResult> GetDriverAndTransportInfoAsync(
        [FromQuery] GetDriverAndTransportInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    //[Authorize(nameof(PermissionCode.PresentTrackingInfoCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
    [FromBody] CreatePresentTrackingInfoCommand command,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(command, cancellationToken));
}
