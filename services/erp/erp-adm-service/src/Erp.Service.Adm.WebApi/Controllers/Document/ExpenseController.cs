
namespace Erp.Service.Adm.WebApi;

[Authorize(AdmPermissionCode.ExpenseView)]
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

    [Authorize(AdmPermissionCode.ExpenseCreate)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] ExpenseCreateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenseEdit)]
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(
        [FromBody] ExpenseUpdateCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenseAccept)]
    [HttpPost]
    public async Task<IActionResult> AcceptAsync(
        [FromBody] ExpenseAcceptCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenselCancel)]
    [HttpPost]
    public async Task<IActionResult> CancelAsync(
        [FromBody] ExpenseCancelCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenseSend)]
    [HttpPost]
    public async Task<IActionResult> SendAsync(
        [FromBody] ExpenseSendCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenseRevoke)]
    [HttpPost]
    public async Task<IActionResult> RevokeAsync(
        [FromBody] ExpenseRevokeCommand command,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(command, cancellationToken));

    [Authorize(AdmPermissionCode.ExpenseDelete)]
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
