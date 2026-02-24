using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryQuery :
    IRequest<CountryDto>
{ }
