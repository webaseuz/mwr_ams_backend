namespace Erp.Service.Adm.Models;

public class ExpenseInsuranceUpdateCommand
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public int InsuranceTypeId { get; set; }
    public string InsNumber { get; set; } = null!;
    public int ContractorId { get; set; }
    public decimal Price { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<ExpenseFileDto> Files { get; set; } = new();
}
