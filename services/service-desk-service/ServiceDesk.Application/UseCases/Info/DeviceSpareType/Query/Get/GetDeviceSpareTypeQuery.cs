using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeQuery :
    IRequest<DeviceSpareTypeDto>
{ }
