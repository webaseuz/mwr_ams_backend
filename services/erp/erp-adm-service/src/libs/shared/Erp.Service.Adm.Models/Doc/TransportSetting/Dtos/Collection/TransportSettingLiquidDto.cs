namespace Erp.Service.Adm.Models;

public class TransportSettingLiquidDto
{
    public long Id { get; set; }
    public int LiquidTypeId { get; set; }
    public string LiquidTypeName { get; set; }
    public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
