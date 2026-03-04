namespace Erp.Service.Adm.Models;

public class ExpenseInspectionUpdateCommand
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public string Details { get; set; }
    public int InspectionTypeId { get; set; }
    public decimal Price { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<ExpenseFileDto> Files { get; set; } = new();
}
