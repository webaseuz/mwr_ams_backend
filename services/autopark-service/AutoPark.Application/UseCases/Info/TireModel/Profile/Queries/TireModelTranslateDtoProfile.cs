using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TireModels;

public class TireModelTranslateDtoProfile : Profile
{
    public TireModelTranslateDtoProfile()
    {
        CreateMap<TireModelTranslate, TireModelTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
