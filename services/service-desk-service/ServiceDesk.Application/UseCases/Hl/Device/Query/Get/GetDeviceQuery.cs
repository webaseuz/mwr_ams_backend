using MediatR;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceQuery :
    IRequest<DeviceDto>
{ }
