using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipTranslateDtoProfile : Profile
{
    public CitizenshipTranslateDtoProfile()
    {
        CreateMap<CitizenshipTranslate, CitizenshipTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}