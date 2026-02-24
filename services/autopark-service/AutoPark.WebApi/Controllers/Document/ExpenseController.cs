using AutoPark.Application;
using AutoPark.Application.UseCases.Expenses;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] DownloadExpenseFileCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadTableFilesAsync(
    string documentName,
    [FromForm] IFormFile[] files,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(new UploadExpenseTablesFileCommand(documentName, files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadTableFileAsync(
        [FromBody] DownloadExpenseTablesFileCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
