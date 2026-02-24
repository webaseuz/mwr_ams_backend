using AutoPark.Application;
using AutoPark.Application.UseCases.TrackingInfos;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.PresentTrackingInfoView))]
[ApiController]
[Route("[controller]/[action]")]
public class TrackingInfoController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
    [FromQuery] GetTrackingInfoBriefResultQuery query,
    CancellationToken cancellationToken)
    {
        var stream = Mediator.CreateStream(query, cancellationToken);
        var list = new List<List<TrackingInfoBriefDto>>();

        await foreach (var group in stream.WithCancellation(cancellationToken))
            list.AddRange(group);

        return Ok(list);
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetTrackingInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetTrackingInfoByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetDriverAndTransportInfoAsync(
        [FromQuery] GetDriverAndTransportInfoQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
