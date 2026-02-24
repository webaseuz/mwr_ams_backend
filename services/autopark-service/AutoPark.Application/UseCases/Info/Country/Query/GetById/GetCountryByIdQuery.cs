using MediatR;

namespace AutoPark.Application.UseCases.Countries;

public class GetCountryByIdQuery :
    IRequest<CountryDto>
{
    public int Id { get; set; }
}
