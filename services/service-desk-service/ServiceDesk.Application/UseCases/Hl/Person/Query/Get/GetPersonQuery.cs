using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonQuery :
    IRequest<PersonDto>
{ }
