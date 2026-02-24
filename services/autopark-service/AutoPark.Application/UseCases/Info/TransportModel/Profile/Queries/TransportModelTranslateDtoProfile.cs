using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelTranslateDtoProfile : Profile
{
    public TransportModelTranslateDtoProfile()
    {
        CreateMap<TransportModelTranslate, TransportModelTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
