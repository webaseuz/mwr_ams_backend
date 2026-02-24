using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class LiquidTypeTranslateDtoProfile : Profile
{
    public LiquidTypeTranslateDtoProfile()
    {
        CreateMap<LiquidTypeTranslate, LiquidTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
