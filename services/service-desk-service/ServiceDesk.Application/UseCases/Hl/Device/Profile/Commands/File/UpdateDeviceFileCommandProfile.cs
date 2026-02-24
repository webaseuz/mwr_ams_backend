using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Devices;

public class UpdateDeviceFileCommandProfile :
    Profile
{
    public UpdateDeviceFileCommandProfile()
    {
        CreateMap<UpdateDeviceFileCommand, DeviceFile>();
    }
}
