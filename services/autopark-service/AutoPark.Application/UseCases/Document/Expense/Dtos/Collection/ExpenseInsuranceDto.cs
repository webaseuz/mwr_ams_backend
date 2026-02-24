namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseInsuranceDto
{
    public long Id { get; set; }
    public int InsuranceTypeId { get; set; }
    public DateTime DateOn { get; set; }
    public string InsuranceTypeName { get; set; }
    public string InsNumber { get; set; } = null!;
    public long ContractorId { get; set; }
    public string ContractorName { get; set; }
    public string Details { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public DateTime? InvoiceDateOn { get; set; } = null!;
    public List<ExpenseFileDto> Files { get; set; } = new();
}
