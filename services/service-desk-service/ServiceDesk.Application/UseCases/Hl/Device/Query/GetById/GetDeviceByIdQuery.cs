using MediatR;

namespace ServiceDesk.Application.UseCases.Devices;
    
public class GetDeviceByIdQuery :
    IRequest<DeviceDto>
{
    public int Id { get; set; }
}
