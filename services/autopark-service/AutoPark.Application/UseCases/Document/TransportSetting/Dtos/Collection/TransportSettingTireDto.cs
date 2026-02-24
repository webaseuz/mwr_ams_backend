namespace AutoPark.Application.UseCases.TransportSettings;
public class TransportSettingTireDto
{
    public long Id { get; set; }
    public int TireSizeId { get; set; }
    public int? TireModelId { get; set; }
    public string TireModelName { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}

