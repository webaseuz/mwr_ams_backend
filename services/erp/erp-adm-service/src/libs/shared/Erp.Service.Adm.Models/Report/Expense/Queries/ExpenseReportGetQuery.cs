using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseReportGetQuery : IRequest<List<ExpenseReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
