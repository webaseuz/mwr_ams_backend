using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Currencies;

public class UpdateCurrencyCommandProfile : Profile
{
    public UpdateCurrencyCommandProfile()
    {
        CreateMap<UpdateCurrencyCommand, Currency>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
