using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Currencies;

public class CreateCurrencyCommandProfile : Profile
{
    public CreateCurrencyCommandProfile()
    {
        CreateMap<CreateCurrencyCommand, Currency>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
