using MediatR;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryByIdQuery : 
    IRequest<CountryDto>
{
    public int Id { get; set; }
}
