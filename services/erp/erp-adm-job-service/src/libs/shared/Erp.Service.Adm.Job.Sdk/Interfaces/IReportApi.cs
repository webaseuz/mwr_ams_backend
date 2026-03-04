using Erp.Service.Adm.Job.Models;
using Refit;

namespace Erp.Service.Adm.Job.Sdk;

public interface IReportApi
{
    /// <summary>
    /// Get organization report by region or district
    /// </summary>
    [Post("/Report/Organization")]
    Task<List<OrganizationReportDto>> OrganizationAsync([Body] OrganizationReportQuery query);

    /// <summary>
    /// Print organization report as Excel
    /// </summary>
    [Post("/Report/OrganizationPrintAsExcel")]
    Task<Stream> OrganizationPrintAsExcelAsync([Body] OrganizationReportPrintAsExcelCommand command);
}
