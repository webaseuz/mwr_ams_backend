using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Currencies;

public class CurrencyTranslateDtoProfile : Profile
{
    public CurrencyTranslateDtoProfile()
    {
        CreateMap<CurrencyTranslate, CurrencyTranslateDto>()
            .ForMember(src => src.LanguageName, conf => conf.MapFrom(ent => ent.Language.FullName));
    }
}
