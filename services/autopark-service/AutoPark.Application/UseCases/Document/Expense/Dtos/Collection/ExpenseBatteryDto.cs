namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseBatteryDto
{
    public long Id { get; set; }
    public decimal Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public string BatteryTypeName { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime? InvoiceDateOn { get; set; } = null!;
    public List<ExpenseFileDto> Files { get; set; } = new();
}
