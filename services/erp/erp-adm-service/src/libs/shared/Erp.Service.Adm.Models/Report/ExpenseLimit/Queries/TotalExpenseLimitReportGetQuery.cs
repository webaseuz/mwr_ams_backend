using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TotalExpenseLimitReportGetQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TotalExpenseLimitReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
