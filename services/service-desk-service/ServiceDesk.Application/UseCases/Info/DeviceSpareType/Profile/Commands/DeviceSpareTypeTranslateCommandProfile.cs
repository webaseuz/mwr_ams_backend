using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeTranslateCommandProfile : Profile
{
    public DeviceSpareTypeTranslateCommandProfile()
    {
        CreateMap<DeviceSpareTypeTranslateCommand, DeviceSpareTypeTranslate>();
    }
}
