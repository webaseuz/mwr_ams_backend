using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryQuery :
    IRequest<CountryDto>
{ }
