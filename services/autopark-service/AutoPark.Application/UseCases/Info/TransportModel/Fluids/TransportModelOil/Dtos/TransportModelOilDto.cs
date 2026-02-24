namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelOilDto
{
    public int Id { get; set; }
    public int OilTypeId { get; set; }
    public string OilTypeName { get; set; }
    public int? OilModelId { get; set; }
    public string OilModelName { get; set; }
    public decimal TankVolume { get; set; }
}
