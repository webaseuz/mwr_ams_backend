using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Adm.Bff.Web.WebApi;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class ReportController : ControllerBase
{
    private readonly IReportApi _reportApi;

    public ReportController(IReportApi reportApi)
    {
        _reportApi = reportApi;
    }

    [HttpPost]
    [ProducesResponseType(typeof(List<OrganizationReportDto>), 200)]
    public async Task<IActionResult> OrganizationAsync([FromBody] OrganizationReportQuery query)
        => Ok(await _reportApi.OrganizationAsync(query));

    [HttpPost]
    [ProducesResponseType(typeof(FileResult), 200)]
    public async Task<IActionResult> OrganizationPrintAsExcelAsync([FromBody] OrganizationReportPrintAsExcelCommand command)
    {
        var fileStream = await _reportApi.OrganizationPrintAsExcelAsync(command);

        return File(fileStream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Tashkilot_hisoboti.xlsx");
    }
}
