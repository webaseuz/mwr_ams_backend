using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonByPinflQuery :
        IRequest<PersonDto>
{
    public string Pinfl { get; set; }
}
