namespace Erp.Service.Adm.Models;

public class TransportSettingOilUpdateCommand
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int OilTypeId { get; set; }
    public decimal MonthlyLimit { get; set; }
    public decimal Remaining { get; set; }
}
