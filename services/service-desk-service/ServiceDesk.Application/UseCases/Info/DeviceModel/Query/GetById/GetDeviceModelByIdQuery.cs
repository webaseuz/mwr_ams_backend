using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelByIdQuery :
    IRequest<DeviceModelDto>
{
    public int Id { get; set; }
}
