using MediatR;

namespace AutoPark.Application.UseCases.Currencies;

public class GetCurrencyByIdQuery :
    IRequest<CurrencyDto>
{
    public int Id { get; set; }
}
