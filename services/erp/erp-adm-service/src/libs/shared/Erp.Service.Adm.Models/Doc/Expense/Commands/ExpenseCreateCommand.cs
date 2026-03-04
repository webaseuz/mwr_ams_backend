using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class ExpenseCreateCommand : IRequest<WbHaveId<long>>
{
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public int DriverId { get; set; }
    public int? BranchId { get; set; }
    public string Message { get; set; }

    public List<ExpenseFileDto> Files { get; set; } = new();
    public List<ExpenseBatteryCreateCommand> Batteries { get; set; } = new();
    public List<ExpenseInspectionCreateCommand> Inspections { get; set; } = new();
    public List<ExpenseInsuranceCreateCommand> Insurances { get; set; } = new();
    public List<ExpenseLiquidCreateCommand> Liquids { get; set; } = new();
    public List<ExpenseOilCreateCommand> Oils { get; set; } = new();
    public List<ExpenseTireCreateCommand> Tires { get; set; } = new();
}
