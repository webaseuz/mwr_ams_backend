
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.ExpenseView)]
[ApiController]
[Route("[controller]/[action]")]
public class ExpenseController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetBriefListAsync(
        [FromQuery] ExpenseGetBriefPageResultQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] ExpenseGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetByIdAsync(
        [FromQuery] ExpenseGetByIdQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] ExpenseCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] ExpenseUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseAccept)]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] ExpenseAcceptCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenselCancel)]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] ExpenseCancelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseSend)]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] ExpenseSendCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseRevoke)]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] ExpenseRevokeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseDelete)]
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(
        [FromBody] ExpenseDeleteCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadFilesAsync(
    [FromForm] IFormFile[] files,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(new ExpenseFileUploadCommand(files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadFileAsync(
        [FromBody] ExpenseFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> UploadTableFilesAsync(
    string documentName,
    [FromForm] IFormFile[] files,
    CancellationToken cancellationToken)
    => Ok(await Mediator.Send(new ExpenseTablesFileUploadCommand(documentName, files), cancellationToken));

    [HttpPost]
    public async Task<IActionResult> DownloadTableFileAsync(
        [FromBody] ExpenseTablesFileDownloadCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));
}
