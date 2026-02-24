using AutoMapper;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;


public class CreatePersonCommandProfile : Profile
{
    public CreatePersonCommandProfile()
    {
        CreateMap<CreatePersonCommand, Person>();
    }
}
