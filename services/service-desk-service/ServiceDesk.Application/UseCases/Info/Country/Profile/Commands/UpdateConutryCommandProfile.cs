using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class UpdateConutryCommandProfile : Profile
{
    public UpdateConutryCommandProfile()
    {
        CreateMap<UpdateCountryCommand, Country>()
            .ForMember(src => src.Translates, conf => conf.Ignore());
    }
}
