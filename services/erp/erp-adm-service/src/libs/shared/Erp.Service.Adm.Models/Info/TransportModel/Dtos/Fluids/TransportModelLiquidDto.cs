namespace Erp.Service.Adm.Models;

public class TransportModelLiquidDto
{
    public int Id { get; set; }
    public int LiquidTypeId { get; set; }
    public string LiquidTypeName { get; set; }
    public decimal TankVolume { get; set; }
}
