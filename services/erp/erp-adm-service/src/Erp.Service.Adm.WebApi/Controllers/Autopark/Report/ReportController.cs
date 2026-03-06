
namespace Erp.Service.Adm.WebApi;

[Authorize(AutoparkPermissionCode.ExpenseReportAllView)]
[ApiController]
[Route("[controller]/[action]")]
public class ReportController : BaseController
{
    [Authorize(AutoparkPermissionCode.ExpenseReportAllView)]
    [HttpGet]
    public async Task<IActionResult> GetExpenseReportBriefListAsync(
        [FromQuery] TotalExpenseReportGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetExpenseReportAsync(
        [FromQuery] ExpenseReportGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(AutoparkPermissionCode.ExpenseReportAllView)]
    [HttpGet]
    public async Task<IActionResult> GetExpenseLimitReportBriefListAsync(
        [FromQuery] TotalExpenseLimitReportGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetExpenseLimitReportAsync(
        [FromQuery] ExpenseLimitReportGetQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
