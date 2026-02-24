using MediatR;

namespace AutoPark.Application.UseCases.Persons;

public class GetPersonQueryHandler :
    IRequestHandler<GetPersonQuery, PersonDto>
{
    public Task<PersonDto> Handle(
        GetPersonQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new PersonDto());
}
