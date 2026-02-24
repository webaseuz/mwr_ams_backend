using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeByIdQuery :
    IRequest<DeviceSpareTypeDto>
{
    public int Id { get; set; }
}
