namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingOilDto
{
    public long Id { get; set; }
    public int OilTypeId { get; set; }
    public string OilTypeName { get; set; }
    //public int OilModelId { get; set; }
    //public string OilModelName { get; set; }
    //public decimal TankVolume { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}

