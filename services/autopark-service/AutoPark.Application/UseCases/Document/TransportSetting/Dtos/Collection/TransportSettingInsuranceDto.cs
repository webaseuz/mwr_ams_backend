namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingInsuranceDto
{
    public long Id { get; set; }
    public int InsuranceTypeId { get; set; }
    public string InsuranceTypeName { get; set; }
    public string InsNumber { get; set; } = null!;
    public DateTime ExpireAt { get; set; }
    public long ContractorId { get; set; }
    public string ContractorName { get; set; }
    public long ResponsiblePersonId { get; set; }
    public string ResponsiblePersonName { get; set; }
    public string Details { get; set; }
    public int NotifyBeforeDay { get; set; }
}
