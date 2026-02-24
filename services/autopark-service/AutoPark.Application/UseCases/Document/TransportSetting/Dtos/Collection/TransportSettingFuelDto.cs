namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingFuelDto
{
    public long Id { get; set; }
    public int FuelTypeId { get; set; }
    public string FuelTypeName { get; set; }
    //public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
