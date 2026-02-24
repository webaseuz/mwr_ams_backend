using MediatR;

namespace AutoPark.Application.UseCases.ExpenseLimits;

public class GetExpenseLimitReportQuery :
    IRequest<List<ExpenseLimitReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
