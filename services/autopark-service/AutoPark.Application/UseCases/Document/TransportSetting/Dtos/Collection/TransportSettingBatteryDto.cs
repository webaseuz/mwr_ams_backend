namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingBatteryDto
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public int BatteryTypeId { get; set; }
    public string BatteryTypeName { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}
