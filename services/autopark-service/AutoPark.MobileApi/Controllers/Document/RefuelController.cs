using AutoPark.Application;
using AutoPark.Application.UseCases.Refuels;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AutoPark.MobileApi.Controllers;

[Authorize(nameof(PermissionCode.RefuelView))]
[ApiController]
[Route("[controller]/[action]")]
public class RefuelController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetRefuelBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetRefuelQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetRefuelByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelAccept))]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelSend))]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] SendRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelRevoke))]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] RevokeRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelCancel))]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.RefuelDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteRefuelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new UploadRefuelFileCommand(files), cancellationToken));

    [HttpGet("{fileId}")]
    public async Task<IActionResult> DownloadFileAsync(
        Guid fileId,
        CancellationToken cancellationToken)
    {
        StorageFile file = await Mediator.Send(new DownloadMobileRefuelFileCommand(fileId), cancellationToken);
        var res = new FileExtensionContentTypeProvider();
        res.TryGetContentType(file.FileName, out string contentType);

        return File(file.GetStream(), contentType);
    }
}
