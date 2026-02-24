using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.ServiceApplications;

namespace ServiceDesk.WebApi.Controllers;

[Authorize(nameof(PermissionCode.ServiceApplicationView))]
[ApiController]
[Route("[controller]/[action]")]
public class ServiceApplicationController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetServiceApplicationBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetServiceApplicationQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetServiceApplicationByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationInProcess))]
    [HttpPost]
    public async Task<IActionResult> InProcessAsync(
        [FromBody] InProcessServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationSend))]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] SendServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationRevoke))]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] RevokeServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationCancelByClient))]
    [HttpPost]
    public async Task<IActionResult> CancelByClientAsync(
        [FromBody] CancelByClientServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationCancelByExecutor))]
    [HttpPost]
    public async Task<IActionResult> CancelByExecutorAsync(
        [FromBody] CancelByExecutorServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationFinishByExecutor))]
    [HttpPost]
    public async Task<IActionResult> FinishByExecutorAsync(
        [FromBody] FinishByExecutorServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
    
    [Authorize(nameof(PermissionCode.ServiceApplicationFail))]
    [HttpPost]
    public async Task<IActionResult> FailAsync(
        [FromBody] FailServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
    
    [Authorize(nameof(PermissionCode.ServiceApplicationWaitSpares))]
    [HttpPost]
    public async Task<IActionResult> WaitSparesAsync(
        [FromBody] WaitSparesServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationFinished))]
    [HttpPost]
    public async Task<IActionResult> FinishAsync(
        [FromBody] FinishServiceApplicationCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ServiceApplicationCreate))]
    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
        [FromForm] IFormFile[] files,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new UploadServiceApplicationFileCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DownloadServiceApplicationFileCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
