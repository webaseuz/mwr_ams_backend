using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class DeviceSpareTypeTranslateDtoProfile : Profile
{
    public DeviceSpareTypeTranslateDtoProfile()
    {
        CreateMap<DeviceSpareTypeTranslate, DeviceSpareTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
