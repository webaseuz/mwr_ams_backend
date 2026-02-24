using Bms.Common.Infrastructure;
using Bms.Core.Infrastructure;
using Bms.WEBASE.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ServiceDesk.Application;
using ServiceDesk.Application.UseCases.Document.ServiceApplications;
using ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.GetSpareTurnoverReportAsPagedResult;
using ServiceDesk.Application.UseCases.Report.SpareTurnover.Query.SpareTurnoverBriefList;

namespace ServiceDesk.WebApi.Controllers.Report
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SpareTurnoverController : MediatorController
    {
        [Authorize(nameof(PermissionCode.SpareTurnoverReportBranchView), nameof(PermissionCode.SpareTurnoverReportAllView))]
        [HttpGet]
        public async Task<IActionResult> GetReportListAsync(
            [FromQuery] GetSpareTurnoverReportBriefListQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));

        [Authorize(nameof(PermissionCode.SpareTurnoverReportBranchView), nameof(PermissionCode.SpareTurnoverReportAllView))]
        [HttpGet]
        public async Task<IActionResult> GetBriefListAsync(
            [FromQuery] GetSpareTurnoverBriefListQuery query,
            CancellationToken cancellationToken)
            => Ok(await Mediator.Send(query, cancellationToken));

        [Authorize(nameof(PermissionCode.SpareTurnoverReportBranchView), nameof(PermissionCode.SpareTurnoverReportAllView))]
        [HttpGet]
        public async Task<IActionResult> ExportBriefListAsync(
            [FromQuery] ExportSpareTurnoverReportBriefListQuery query,
            CancellationToken cancellationToken)
        {
            var excelData = await Mediator.Send(query, cancellationToken);
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SpareTurnoverReport.xlsx");
        }
    }
}
