using Bms.WEBASE.Models;
using MediatR;
namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseTireCommand :
    IRequest<IHaveId<long>>
{
    public decimal Quantity { get; set; }
    public int TireSizeId { get; set; }
    public int? TireModelId { get; set; }
    public DateTime DateOn { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal MileAge { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime? InvoiceDateOn { get; set; }
    public List<CreateExpenseTablesFileCommand> Files { get; set; } = new();
}
