using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.OilModels;

public class OilModelTranslateDtoProfile : Profile
{
    public OilModelTranslateDtoProfile()
    {
        CreateMap<OilModelTranslate, OilModelTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
