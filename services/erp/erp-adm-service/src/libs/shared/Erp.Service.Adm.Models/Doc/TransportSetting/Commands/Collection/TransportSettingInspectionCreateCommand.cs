namespace Erp.Service.Adm.Models;

public class TransportSettingInspectionCreateCommand
{
    public DateTime DateAt { get; set; }
    public DateTime ExpireAt { get; set; }
    public int ResponsiblePersonId { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
