using AutoMapper;
using AutoPark.Domain;

namespace AutoPark.Application.UseCases.Persons;

public class UpdatePersonCommandProfile : Profile
{
    public UpdatePersonCommandProfile()
    {
        CreateMap<UpdatePersonCommand, Person>()
            .ForMember(src => src.BirthOn, ex => ex.MapFrom(a => a.BirthOn));
    }
}
