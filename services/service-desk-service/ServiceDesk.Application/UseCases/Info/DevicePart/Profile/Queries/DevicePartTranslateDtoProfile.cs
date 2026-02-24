using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class DevicePartTranslateDtoProfile : Profile
{
    public DevicePartTranslateDtoProfile()
    {
        CreateMap<DevicePartTranslate, DevicePartTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
