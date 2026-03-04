namespace Erp.Service.Adm.Models;

public class TransportSettingTireCreateCommand
{
    public int Quantity { get; set; }
    public int TireSizeId { get; set; }
    public int? TireModelId { get; set; }
    public string Size { get; set; }
    public DateTime ProducedAt { get; set; }
    public decimal MileAge { get; set; }
}
