using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelQuery :
    IRequest<DeviceModelDto>
{ }
