using Bms.WEBASE.Models;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseDto :
        IHaveIdProp<long>
{
    public long Id { get; set; }
    public string DocNumber { get; set; } = null!;
    public DateTime DocDate { get; set; }
    public int TransportId { get; set; }
    public string TransportInfo { get; set; }
    public int DriverId { get; set; }
    public string DriverName { get; set; }
    public int? BranchId { get; set; }
    public string BranchName { get; set; }
    public string Message { get; set; }
    public int StatusId { get; private set; }
    public string StatusName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool CanCreateForAllBranch { get; set; }
    public List<ExpenseFileDto> Files { get; set; } = new();
    public List<ExpenseBatteryDto> Batteries { get; set; } = new();
    public List<ExpenseInspectionDto> Inspections { get; set; } = new();
    public List<ExpenseInsuranceDto> Insurances { get; set; } = new();
    public List<ExpenseLiquidDto> Liquids { get; set; } = new();
    public List<ExpenseOilDto> Oils { get; set; } = new();
    public List<ExpenseTireDto> Tires { get; set; } = new();
    public bool CanInvoice { get; set; }
}
