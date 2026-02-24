using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class CreateExpenseCommand :
    IRequest<IHaveId<long>>
{
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public string Message { get; set; }
    public List<CreateExpenseFileCommand> Files { get; set; } = new();
    public List<CreateExpenseBatteryCommand> Batteries { get; set; } = new();
    public List<CreateExpenseInspectionCommand> Inspections { get; set; } = new();
    public List<CreateExpenseInsuranceCommand> Insurances { get; set; } = new();
    public List<CreateExpenseLiquidCommand> Liquids { get; set; } = new();
    public List<CreateExpenseOilCommand> Oils { get; set; } = new();
    public List<CreateExpenseTireCommand> Tires { get; set; } = new();

}
