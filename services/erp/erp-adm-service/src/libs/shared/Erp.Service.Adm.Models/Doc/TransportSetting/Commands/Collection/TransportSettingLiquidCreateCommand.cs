namespace Erp.Service.Adm.Models;

public class TransportSettingLiquidCreateCommand
{
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
