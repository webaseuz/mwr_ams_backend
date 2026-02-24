using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class CreateCountryCommandProfile : Profile
{
    public CreateCountryCommandProfile()
    {
        CreateMap<CreateCountryCommand, Country>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
