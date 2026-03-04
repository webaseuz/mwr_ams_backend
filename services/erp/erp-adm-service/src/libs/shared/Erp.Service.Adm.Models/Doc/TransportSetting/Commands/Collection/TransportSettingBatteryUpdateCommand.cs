namespace Erp.Service.Adm.Models;

public class TransportSettingBatteryUpdateCommand
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}
