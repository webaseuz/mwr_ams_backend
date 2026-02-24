using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportTypes;

public class TransportTypeTranslateDtoProfile : Profile
{
    public TransportTypeTranslateDtoProfile()
    {
        CreateMap<TransportTypeTranslate, TransportTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
