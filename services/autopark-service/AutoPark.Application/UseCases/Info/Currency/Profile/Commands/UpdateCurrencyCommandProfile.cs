using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Currencies;

public class UpdateCurrencyCommandProfile : Profile
{
    public UpdateCurrencyCommandProfile()
    {
        CreateMap<UpdateCurrencyCommand, Currency>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
