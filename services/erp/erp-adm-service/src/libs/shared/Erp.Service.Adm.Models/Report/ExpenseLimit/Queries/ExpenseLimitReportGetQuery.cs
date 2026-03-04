using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseLimitReportGetQuery : IRequest<List<ExpenseLimitReportListDto>>
{
    public int? BranchId { get; set; }
    public int? TransportId { get; set; }
    public int? DriverId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
