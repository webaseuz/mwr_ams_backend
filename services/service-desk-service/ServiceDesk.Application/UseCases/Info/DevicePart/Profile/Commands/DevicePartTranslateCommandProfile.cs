using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DevicePartTranslateCommandProfile : Profile
{
    public DevicePartTranslateCommandProfile()
    {
        CreateMap<DevicePartTranslateCommand, DevicePartTranslate>();
    }
}
