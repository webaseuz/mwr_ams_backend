using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelQueryHandler :
    IRequestHandler<GetDeviceModelQuery, DeviceModelDto>
{
    public Task<DeviceModelDto> Handle(
		GetDeviceModelQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new DeviceModelDto());
}
