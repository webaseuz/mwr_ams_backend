using MediatR;

namespace AutoPark.Application.UseCases.Citizenships;

public class GetCitizenshipQueryHandler :
    IRequestHandler<GetCitizenshipQuery, CitizenshipDto>
{
    public Task<CitizenshipDto> Handle(
        GetCitizenshipQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new CitizenshipDto());
}
