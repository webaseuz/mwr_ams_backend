using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Persons;


public class CreatePersonCommandProfile : Profile
{
    public CreatePersonCommandProfile()
    {
        CreateMap<CreatePersonCommand, Person>()
            .ForMember(src => src.BirthOn, exp => exp.MapFrom(a => a.BirthOn))
            .ForMember(src => src.MiddleName, exp => exp.MapFrom(a => a.MiddleName))
            .ForMember(src => src.LastName, exp => exp.MapFrom(a => a.LastName))
            .ForMember(src => src.FirstName, exp => exp.MapFrom(a => a.FirstName))

            ;
    }
}
