namespace Erp.Service.Adm.Models;

public class ExpenseLimitReportListDto
{
    public string ExpenseType { get; set; }
    public decimal ExpensePrice { get; set; }
    public decimal MonthlyLimit { get; set; }
    public bool IsOverLimit { get; set; }
}
