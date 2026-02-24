using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeQueryHandler :
    IRequestHandler<GetDeviceSpareTypeQuery, DeviceSpareTypeDto>
{
    public Task<DeviceSpareTypeDto> Handle(
		GetDeviceSpareTypeQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DeviceSpareTypeDto());
}
