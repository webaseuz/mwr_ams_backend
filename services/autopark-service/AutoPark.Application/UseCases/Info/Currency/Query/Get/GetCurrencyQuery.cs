using MediatR;

namespace AutoPark.Application.UseCases.Currencies;

public class GetCurrencyQuery :
    IRequest<CurrencyDto>
{ }
