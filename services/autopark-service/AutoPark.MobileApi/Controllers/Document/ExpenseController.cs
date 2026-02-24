using AutoPark.Application;
using AutoPark.Application.UseCases.Expenses;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AutoPark.MobileApi.Controllers;

[Authorize(nameof(PermissionCode.ExpenseView))]
[ApiController]
[Route("[controller]/[action]")]
public class ExpenseController : MediatorController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] GetExpenseBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetExpenseQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] GetExpenseByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseCreate))]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseEdit))]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] UpdateExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseAccept))]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] AcceptExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenselCancel))]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] CancelExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseSend))]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] SendExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseRevoke))]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] RevokeExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseDelete))]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] DeleteExpenseCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
    [FromForm] IFormFile[] files,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(new UploadExpenseFileCommand(files), cancellationToken));

    [HttpGet("{fileId}")]
    public async Task<IActionResult> DownloadFileAsync(
        Guid fileId,
        CancellationToken cancellationToken)
    {
        StorageFile file = await Mediator.Send(new DownloadMobileExpenseFileCommand(fileId), cancellationToken);
        var res = new FileExtensionContentTypeProvider();
        res.TryGetContentType(file.FileName, out string contentType);

        return File(file.GetStream(), contentType);
    }
}

