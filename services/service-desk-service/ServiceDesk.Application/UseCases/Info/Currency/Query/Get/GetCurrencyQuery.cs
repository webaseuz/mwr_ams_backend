using MediatR;

namespace ServiceDesk.Application.UseCases.Currencies;

public class GetCurrencyQuery :
    IRequest<CurrencyDto>
{ }
