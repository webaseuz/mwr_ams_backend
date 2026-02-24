using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class UpdateDeviceSpareTypeCommand :
    IHaveIdProp<int>,
    IRequest<IHaveId<int>>
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
	public string Nomenclature { get; set; } = null!;
	public int DeviceTypeId { get; set; }
	public int DevicePartId { get; set; }
	public int? DeviceModelId { get; set; }

	public List<DeviceSpareTypeTranslateCommand> Translates { get; set; } = new();
}
