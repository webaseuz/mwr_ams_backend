using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class DeviceTypeTranslateDtoProfile : Profile
{
    public DeviceTypeTranslateDtoProfile()
    {
        CreateMap<DeviceTypeTranslate, DeviceTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
