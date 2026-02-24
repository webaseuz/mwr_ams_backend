using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class UpdateDeviceModelCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
    public int DeviceTypeId { get; set; }

    public List<DeviceModelTranslateCommand> Translates { get; set; } = new();
}
