using AutoPark.Application;
using AutoPark.Application.UseCases.TransportSettings;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class TransportSettingController : MediatorController
{
    [Authorize(nameof(PermissionCode.TransportSettingView))]
    [HttpGet]
    public async Task<IActionResult> GetAsync(
       [FromQuery] GetTransportSettingQuery query,
       CancellationToken cancellationToken)
       => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingView))]
    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetTransportSettingByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingView))]
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetTransportSettingBriefAsPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
       [FromBody] CreateTransportSettingCommand command,
       CancellationToken cancellationToken)
       => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateTransportSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingEdit))]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptTransportSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingEdit))]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelTransportSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.TransportSettingDelete))]
    [HttpPost]
    public async Task<IActionResult> Delete(
        [FromBody] DeleteTransportSettingCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new UploadTransportSettingFileCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DownloadTransportSettingFileCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

}
