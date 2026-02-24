using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Report;

public class GetTotalExpenseReportQuery :
    SortFilterPageOptions,
    IRequest<PagedResult<TotalExpenseReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
