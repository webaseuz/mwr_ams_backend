using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseLiquidCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public int LiquidTypeId { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<UpdateExpenseTablesFileCommand> Files { get; set; } = new();
}
