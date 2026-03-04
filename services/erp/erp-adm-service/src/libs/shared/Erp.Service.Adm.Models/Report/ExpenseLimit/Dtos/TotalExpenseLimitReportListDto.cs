namespace Erp.Service.Adm.Models;

public class TotalExpenseLimitReportListDto
{
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int BranchId { get; set; }
    public string BranchName { get; set; }
    public string TransportInfo { get; set; }
    public string Driver { get; set; }
    public decimal TotalSum { get; set; }
    public bool IsOverLimit { get; set; }
}
