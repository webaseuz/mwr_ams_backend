using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class DeviceModelTranslateDtoProfile : Profile
{
    public DeviceModelTranslateDtoProfile()
    {
        CreateMap<DeviceModelTranslate, DeviceModelTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
