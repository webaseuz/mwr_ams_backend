using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Persons;

public class PersonBriefDtoProfile : Profile
{
    public PersonBriefDtoProfile()
    {
        //PersonBriefDto
        CreateMap<Person, PersonPriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(x => x.Branch.FullName))
            ;
    }
}
