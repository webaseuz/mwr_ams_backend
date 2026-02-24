using AutoMapper;
using ServiceDesk.Application.UseCases.Persons;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Persons;

public class UpdatePersonCommandProfile : Profile
{
    public UpdatePersonCommandProfile()
    {
        CreateMap<UpdatePersonCommand, Person>();
    }
}
