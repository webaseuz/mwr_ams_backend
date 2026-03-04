namespace Erp.Service.Adm.Models;

public class TransportSettingBatteryCreateCommand
{
    public int Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}
