using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonQuery :
    IRequest<PersonDto>
{ }
