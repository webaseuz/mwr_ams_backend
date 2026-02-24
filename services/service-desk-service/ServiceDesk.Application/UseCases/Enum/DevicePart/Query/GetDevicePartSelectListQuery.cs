using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartSelectListQuery : IRequest<SelectList<int>>
{
    public int? DeviceTypeId { get; set; }
}
