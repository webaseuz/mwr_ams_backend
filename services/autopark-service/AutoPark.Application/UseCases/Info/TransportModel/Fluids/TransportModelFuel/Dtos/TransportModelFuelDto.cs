namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelFuelDto
{
    public int Id { get; set; }
    public int FuelTypeId { get; set; }
    public string FuelTypeName { get; set; }
    public decimal TankVolume { get; set; }
}
