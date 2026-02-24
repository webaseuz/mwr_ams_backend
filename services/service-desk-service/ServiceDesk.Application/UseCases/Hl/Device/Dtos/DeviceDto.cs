namespace ServiceDesk.Application.UseCases.Devices;

public class DeviceDto
{
    public int Id { get; set; }
    public string UniqueNumber { get; set; }
    public string SerialNumber { get; set; }
    public int BranchId { get; set; }
    public int DeviceTypeId { get; set; }
    public int DeviceModelId { get; set; }
    public long? ManufacturerId { get; set; }
    public long? ServiceContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public int StateId { get; private set; }
    public string StateName { get; set; }
    public bool CanCreateForAllBranch { get; set; }

    public List<DeviceFileDto> Files { get; set; } = new();
}
