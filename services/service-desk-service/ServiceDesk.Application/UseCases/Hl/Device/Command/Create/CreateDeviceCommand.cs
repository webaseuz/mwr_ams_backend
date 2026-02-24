using MediatR;
using Bms.WEBASE.Models;

namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceCommand :
    IRequest<IHaveId<int>>
{
    public string UniqueNumber { get; set; }
    public string SerialNumber { get; set; }
    public int BranchId { get; set; }
    public int DeviceTypeId { get; set; }
    public int DeviceModelId { get; set; }
    public long? ManufacturerId { get; set; }
    public long? ServiceContractorId { get; set; }
    public long ResponsiblePersonId { get; set; }
    public List<CreateDeviceFileCommand> Files { get; set; } = new();
}
