namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class ServiceApplicationPartDto
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public int? DevicePartId { get; set; }
    public string DevicePartName { get; set; }
    public int ApplicationPurposeId { get; set; }
    public string ApplicationPurposeName { get; set; }
    public int? ServiceTypeId { get; set; }
    public string ServiceTypeName { get; set; }
}
