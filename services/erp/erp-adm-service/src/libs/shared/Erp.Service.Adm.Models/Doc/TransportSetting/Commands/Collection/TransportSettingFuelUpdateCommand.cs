namespace Erp.Service.Adm.Models;

public class TransportSettingFuelUpdateCommand
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int FuelTypeId { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
