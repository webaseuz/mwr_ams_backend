using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class CreateDevicePartCommand :
    IRequest<IHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
    public int DeviceTypeId { get; set; }
    public List<DevicePartTranslateCommand> Translates { get; set; } = new();
}
