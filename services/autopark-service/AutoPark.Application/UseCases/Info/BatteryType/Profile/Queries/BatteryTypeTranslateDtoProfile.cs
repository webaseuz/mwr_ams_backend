using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.BatteryTypes;

public class BatteryTypeTranslateDtoProfile : Profile
{
    public BatteryTypeTranslateDtoProfile()
    {
        CreateMap<BatteryTypeTranslate, BatteryTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
