using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeQueryHandler :
    IRequestHandler<GetDeviceTypeQuery, DeviceTypeDto>
{
    public Task<DeviceTypeDto> Handle(
		GetDeviceTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DeviceTypeDto());
}
