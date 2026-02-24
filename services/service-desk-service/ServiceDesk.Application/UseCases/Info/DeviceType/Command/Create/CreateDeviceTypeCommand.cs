using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class CreateDeviceTypeCommand :
    IRequest<IHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
    //public int BaseDeviceTypeId { get; set; }
    public List<DeviceTypeTranslateCommand> Translates { get; set; } = new();
}
