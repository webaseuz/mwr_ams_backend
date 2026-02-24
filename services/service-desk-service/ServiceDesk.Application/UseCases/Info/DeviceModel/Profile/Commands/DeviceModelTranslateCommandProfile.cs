using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class DeviceModelTranslateCommandProfile : Profile
{
    public DeviceModelTranslateCommandProfile()
    {
        CreateMap<DeviceModelTranslateCommand, DeviceModelTranslate>();
    }
}
