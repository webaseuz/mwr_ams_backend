using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

class CreateDriverCommandProfile :
    Profile
{
    public CreateDriverCommandProfile()
    {
        CreateMap<CreateDriverCommand, Driver>()
            .ForMember(src => src.Person, conf => conf.Ignore());

    }
}
