namespace Erp.Service.Adm.Models;

public class TransportSettingFuelCreateCommand
{
    public int FuelTypeId { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
