using MediatR;

namespace AutoPark.Application.UseCases.Report;

public class GetExpenseReportQuery :
    IRequest<List<ExpenseReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
