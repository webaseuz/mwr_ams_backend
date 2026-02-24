using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportBrands;

public class TransportBrandTranslateDtoProfile : Profile
{
    public TransportBrandTranslateDtoProfile()
    {
        CreateMap<TransportBrandTranslate, TransportBrandTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
