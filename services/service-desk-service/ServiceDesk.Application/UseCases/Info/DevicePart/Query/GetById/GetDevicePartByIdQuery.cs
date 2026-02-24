using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartByIdQuery :
    IRequest<DevicePartDto>
{
    public int Id { get; set; }
}
