using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilTypes;

public class OilTypeTranslateDtoProfile : Profile
{
    public OilTypeTranslateDtoProfile()
    {
        CreateMap<OilTypeTranslate, OilTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
