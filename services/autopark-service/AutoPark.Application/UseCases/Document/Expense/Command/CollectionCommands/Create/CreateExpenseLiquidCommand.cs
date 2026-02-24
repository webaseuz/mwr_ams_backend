using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseLiquidCommand :
    IRequest<IHaveId<long>>
{
    public int LiquidTypeId { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<CreateExpenseTablesFileCommand> Files { get; set; } = new();
}
