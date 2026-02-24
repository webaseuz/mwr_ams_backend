using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class TransportUseTypeTranslateDtoProfile : Profile
{
    public TransportUseTypeTranslateDtoProfile()
    {
        CreateMap<TransportUseTypeTranslate, TransportUseTypeTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
