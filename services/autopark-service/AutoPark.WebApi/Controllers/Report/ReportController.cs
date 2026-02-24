using AutoPark.Application;
using AutoPark.Application.UseCases.ExpenseLimits;
using AutoPark.Application.UseCases.Report;
using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AutoPark.WebApi.Controllers;

[Authorize(nameof(PermissionCode.ExpenseReportAllView))]
[ApiController]
[Route("[controller]/[action]")]
public class ReportController : MediatorController
{
    [Authorize(nameof(PermissionCode.ExpenseReportAllView))]
    [HttpGet]
    public async Task<IActionResult> GetExpenseReportBriefListAsync(
        [FromQuery] GetTotalExpenseReportQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetExpenseReportAsync(
        [FromQuery] GetExpenseReportQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [Authorize(nameof(PermissionCode.ExpenseReportAllView))]
    [HttpGet]
    public async Task<IActionResult> GetExpenseLimitReportBriefListAsync(
        [FromQuery] GetTotalExpenseLimitReportQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> GetExpenseLimitReportAsync(
        [FromQuery] GetExpenseLimitReportQuery query,
        CancellationToken cancellationToken)
        => Ok(await Mediator.Send(query, cancellationToken));
}
