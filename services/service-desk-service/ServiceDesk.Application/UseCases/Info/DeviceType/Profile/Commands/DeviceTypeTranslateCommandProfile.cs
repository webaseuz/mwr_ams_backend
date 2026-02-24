using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeTranslateCommandProfile : Profile
{
    public DeviceTypeTranslateCommandProfile()
    {
        CreateMap<DeviceTypeTranslateCommand, DeviceTypeTranslate>();
    }
}
