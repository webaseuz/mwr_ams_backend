using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseOilCommand :
    IRequest<IHaveId<long>>
{
    public int OilTypeId { get; set; }
    public int OilModelId { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<CreateExpenseTablesFileCommand> Files { get; set; } = new();
}
