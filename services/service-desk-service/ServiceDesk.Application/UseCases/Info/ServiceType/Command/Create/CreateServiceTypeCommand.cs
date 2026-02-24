using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class CreateServiceTypeCommand :
    IRequest<IHaveId<int>>
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string OrderCode { get; set; } = null!;
	public int DeviceTypeId { get; set; }
    public List<ServiceTypeTranslateCommand> Translates { get; set; } = new();
}
