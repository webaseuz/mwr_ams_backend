using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Drivers;

class UpdateDriverCommandProfile :
    Profile
{
    public UpdateDriverCommandProfile()
    {
        CreateMap<UpdateDriverCommand, Driver>()
            .ForMember(ent => ent.Documents, conf => conf.MapFrom(ent => ent.Documents))
            .ForMember(ent => ent.Person, conf => conf.Ignore());
    }
}
