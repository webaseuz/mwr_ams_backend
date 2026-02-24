using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
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
	public List<UpdateDeviceFileCommand> Files { get; set; } = new();
}
