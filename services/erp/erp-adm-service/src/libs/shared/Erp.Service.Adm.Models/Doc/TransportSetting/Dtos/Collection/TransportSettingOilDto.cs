namespace Erp.Service.Adm.Models;

public class TransportSettingOilDto
{
    public long Id { get; set; }
    public int OilTypeId { get; set; }
    public string OilTypeName { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
