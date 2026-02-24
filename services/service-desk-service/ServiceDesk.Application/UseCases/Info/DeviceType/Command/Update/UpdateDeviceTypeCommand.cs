using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class UpdateDeviceTypeCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
    //public int BaseDeviceTypeId { get; set; }

    public List<DeviceTypeTranslateCommand> Translates { get; set; } = new();
}
