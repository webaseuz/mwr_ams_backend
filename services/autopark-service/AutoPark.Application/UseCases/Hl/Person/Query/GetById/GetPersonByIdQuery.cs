using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonByIdQuery :
    IRequest<PersonDto>
{
    public int Id { get; set; }
}
