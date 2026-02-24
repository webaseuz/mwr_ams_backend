using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseInsuranceCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DateOn { get; set; }
    public int InsuranceTypeId { get; set; }
    public string InsNumber { get; set; } = null!;
    public int ContractorId { get; set; }

    public decimal Price { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<CreateExpenseTablesFileCommand> Files { get; set; } = new();
}
