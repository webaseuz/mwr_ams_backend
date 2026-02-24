using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CurrencyTranslateDtoProfile : Profile
{
    public CurrencyTranslateDtoProfile()
    {
        CreateMap<CurrencyTranslate, CurrencyTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
