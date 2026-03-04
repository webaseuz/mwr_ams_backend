namespace Erp.Service.Adm.Models;

public class TransportSettingInsuranceCreateCommand
{
    public int InsuranceTypeId { get; set; }
    public string InsNumber { get; set; } = null!;
    public DateTime ExpireAt { get; set; }
    public long ContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
