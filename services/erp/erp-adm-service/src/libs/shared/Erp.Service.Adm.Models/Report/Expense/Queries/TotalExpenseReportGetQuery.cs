using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TotalExpenseReportGetQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TotalExpenseReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
