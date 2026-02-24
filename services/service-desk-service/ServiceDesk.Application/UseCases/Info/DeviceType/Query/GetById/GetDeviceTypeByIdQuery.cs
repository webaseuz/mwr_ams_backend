using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeByIdQuery :
    IRequest<DeviceTypeDto>
{
    public int Id { get; set; }
}
