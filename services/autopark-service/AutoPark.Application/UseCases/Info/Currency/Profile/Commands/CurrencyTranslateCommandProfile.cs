using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Currencies;

public class CurrencyTranslateCommandProfile : Profile
{
    public CurrencyTranslateCommandProfile()
    {
        CreateMap<CurrencyTranslateCommand, CurrencyTranslate>();
    }
}
