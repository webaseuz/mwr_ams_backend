namespace Erp.Service.Adm.Models;

public class TransportSettingFuelDto
{
    public long Id { get; set; }
    public int FuelTypeId { get; set; }
    public string FuelTypeName { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
