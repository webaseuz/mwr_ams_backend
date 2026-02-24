using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseInsuranceCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public DateTime DateOn { get; set; }
    public int InsuranceTypeId { get; set; }
    public string InsNumber { get; set; } = null!;
    public int ContractorId { get; set; }

    public decimal Price { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<UpdateExpenseTablesFileCommand> Files { get; set; } = new();
}
