namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseOilDto
{
    public long Id { get; set; }
    public int OilTypeId { get; set; }
    public string OilTypeName { get; set; }
    public int OilModelId { get; set; }
    public string OilModelName { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime? InvoiceDateOn { get; set; } = null!;
    public List<ExpenseFileDto> Files { get; set; } = new();
}

