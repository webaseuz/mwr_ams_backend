using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelSelectListQuery :
    IRequest<SelectList<int>>
{ 
    public int? DeviceTypeId { get; set; }
}
