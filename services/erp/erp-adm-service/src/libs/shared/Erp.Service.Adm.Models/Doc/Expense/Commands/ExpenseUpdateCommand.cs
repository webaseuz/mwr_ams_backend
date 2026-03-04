using MediatR;

namespace Erp.Service.Adm.Models;

public class ExpenseUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public string Message { get; set; }

    public List<ExpenseFileDto> Files { get; set; } = new();
    public List<ExpenseBatteryUpdateCommand> Batteries { get; set; } = new();
    public List<ExpenseInspectionUpdateCommand> Inspections { get; set; } = new();
    public List<ExpenseInsuranceUpdateCommand> Insurances { get; set; } = new();
    public List<ExpenseLiquidUpdateCommand> Liquids { get; set; } = new();
    public List<ExpenseOilUpdateCommand> Oils { get; set; } = new();
    public List<ExpenseTireUpdateCommand> Tires { get; set; } = new();
}
