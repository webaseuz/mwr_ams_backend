namespace AutoPark.Application.UseCases.Expenses;
public class ExpenseTireDto
{
    public long Id { get; set; }
    public int TireSizeId { get; set; }
    public string TireSizeName { get; set; } = null!;
    public int? TireModelId { get; set; }
    public string TireModelName { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime? InvoiceDateOn { get; set; } = null!;
    public List<ExpenseFileDto> Files { get; set; } = new();
}

