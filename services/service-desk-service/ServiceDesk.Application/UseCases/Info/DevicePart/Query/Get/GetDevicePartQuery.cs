using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartQuery :
    IRequest<DevicePartDto>
{ }
