using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CurrencyTranslateCommandProfile : Profile
{
    public CurrencyTranslateCommandProfile()
    {
        CreateMap<CurrencyTranslateCommand, CurrencyTranslate>();
    }
}
