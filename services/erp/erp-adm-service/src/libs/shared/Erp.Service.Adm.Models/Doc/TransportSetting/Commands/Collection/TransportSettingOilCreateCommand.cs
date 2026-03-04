namespace Erp.Service.Adm.Models;

public class TransportSettingOilCreateCommand
{
    public int OilTypeId { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
