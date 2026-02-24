using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class CountryTranslateDtoProfile : Profile
{
    public CountryTranslateDtoProfile()
    {
        CreateMap<CountryTranslate, CountryTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
