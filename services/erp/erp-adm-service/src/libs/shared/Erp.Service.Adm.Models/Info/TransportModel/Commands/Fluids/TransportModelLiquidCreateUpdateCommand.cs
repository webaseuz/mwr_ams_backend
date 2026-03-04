namespace Erp.Service.Adm.Models;

public class TransportModelLiquidCreateUpdateCommand
{
    public int Id { get; set; }
    public int LiquidTypeId { get; set; }
    public decimal TankVolume { get; set; }
}
