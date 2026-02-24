using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPark.Application.UseCases.ExpenseLimits;

[Keyless]
public class TotalExpenseLimitReportListDto
{
    [Column("transport_id")]
    public int TransportId { get; set; }
    [Column("driver_id")]
    public int DriverId { get; set; }
    [Column("branch_id")]
    public int BranchId { get; set; }
    [Column("branch_name")]
    public string BranchName { get; set; }
    [Column("transport_info")]
    public string TransportInfo { get; set; }
    [Column("driver")]
    public string Driver { get; set; }
    [Column("total_sum")]
    public decimal TotalSum { get; set; }
    [Column("is_over_limit")]
    public bool IsOverLimit { get; set; }
}
