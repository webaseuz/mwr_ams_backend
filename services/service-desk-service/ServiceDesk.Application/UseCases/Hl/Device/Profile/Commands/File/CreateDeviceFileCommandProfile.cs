using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class CreateDeviceFileCommandProfile :
    Profile
{
    public CreateDeviceFileCommandProfile()
    {
        CreateMap<CreateDeviceFileCommand, DeviceFile>();
    }
}
