using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportColors;

public class TransportColorTranslateDtoProfile : Profile
{
    public TransportColorTranslateDtoProfile()
    {
        CreateMap<TransportColorTranslate, TransportColorTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
