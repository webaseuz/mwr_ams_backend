namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseInspectionDto
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public int InspectionTypeId { get; set; }
    public string InspectionTypeName { get; set; } = null!;
    public string Details { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime? InvoiceDateOn { get; set; } = null!;
    public List<ExpenseFileDto> Files { get; set; } = new();
}
