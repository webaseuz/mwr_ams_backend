using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeQuery :
    IRequest<DeviceTypeDto>
{ }
