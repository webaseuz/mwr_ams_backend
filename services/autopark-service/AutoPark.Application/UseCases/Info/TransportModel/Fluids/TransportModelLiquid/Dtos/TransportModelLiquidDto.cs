namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelLiquidDto
{
    public int Id { get; set; }
    public int LiquidTypeId { get; set; }
    public string LiquidTypeName { get; set; }
    public decimal TankVolume { get; set; }
}
