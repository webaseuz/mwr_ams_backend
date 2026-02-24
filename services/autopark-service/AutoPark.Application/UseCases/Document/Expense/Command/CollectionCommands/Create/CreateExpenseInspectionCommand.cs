using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseInspectionCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DateOn { get; set; }
    public string Details { get; set; }
    public int InspectionTypeId { get; set; }
    public decimal Price { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<CreateExpenseTablesFileCommand> Files { get; set; } = new();
}
