namespace Erp.Service.Adm.Models;

public class TransportSettingLiquidUpdateCommand
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
