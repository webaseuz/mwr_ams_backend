namespace Erp.Service.Adm.Models;

public class ExpenseReportListDto
{
    public DateTime ExpenseDate { get; set; }
    public string ExpenseType { get; set; }
    public string Type { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal ExpensePrice { get; set; }
}
