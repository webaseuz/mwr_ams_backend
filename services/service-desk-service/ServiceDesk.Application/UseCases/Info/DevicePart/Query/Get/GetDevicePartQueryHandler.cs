using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartQueryHandler :
    IRequestHandler<GetDevicePartQuery, DevicePartDto>
{
    public Task<DevicePartDto> Handle(
		GetDevicePartQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DevicePartDto());
}
