using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class PersonBriefDtoProfile : Profile
{
    public PersonBriefDtoProfile()
    {
        //PersonBriefDto
        CreateMap<Person, PersonPriefDto>();
    }
}
