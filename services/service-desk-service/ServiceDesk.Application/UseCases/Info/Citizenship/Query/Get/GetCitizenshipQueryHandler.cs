using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipQueryHandler :
    IRequestHandler<GetCitizenshipQuery, CitizenshipDto>
{
    public Task<CitizenshipDto> Handle(
        GetCitizenshipQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new CitizenshipDto());
}
