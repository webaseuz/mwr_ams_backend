using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonByIdQuery :
    IRequest<PersonDto>
{
    public int Id { get; set; }
}
