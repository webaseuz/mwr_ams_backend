using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryQueryHandler :
    IRequestHandler<GetCountryQuery, CountryDto>
{
    public Task<CountryDto> Handle(
        GetCountryQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new CountryDto());
}
