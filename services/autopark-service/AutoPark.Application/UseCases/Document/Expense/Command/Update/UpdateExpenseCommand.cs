using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Expenses;

public class UpdateExpenseCommand :
    IHaveIdProp<long>,
    IRequest<IHaveId<long>>
{
    public long Id { get; set; }
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public string Message { get; set; }
    public List<UpdateExpenseFileCommand> Files { get; set; } = new();
    public List<UpdateExpenseBatteryCommand> Batteries { get; set; } = new();
    public List<UpdateExpenseInspectionCommand> Inspections { get; set; } = new();
    public List<UpdateExpenseInsuranceCommand> Insurances { get; set; } = new();
    public List<UpdateExpenseLiquidCommand> Liquids { get; set; } = new();
    public List<UpdateExpenseOilCommand> Oils { get; set; } = new();
    public List<UpdateExpenseTireCommand> Tires { get; set; } = new();

}
