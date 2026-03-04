namespace Erp.Service.Adm.Models;

public class TransportModelOilCreateUpdateCommand
{
    public int Id { get; set; }
    public int OilTypeId { get; set; }
    public int? OilModelId { get; set; }
    public decimal TankVolume { get; set; }
}
