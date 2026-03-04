namespace Erp.Service.Adm.Models;

public class TransportModelFuelCreateUpdateCommand
{
    public int Id { get; set; }
    public int FuelTypeId { get; set; }
    public decimal TankVolume { get; set; }
}
