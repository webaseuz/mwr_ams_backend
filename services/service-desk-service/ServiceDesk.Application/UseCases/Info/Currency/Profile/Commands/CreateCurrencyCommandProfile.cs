using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Currencies;

public class CreateCurrencyCommandProfile : Profile
{
    public CreateCurrencyCommandProfile()
    {
        CreateMap<CreateCurrencyCommand, Currency>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
