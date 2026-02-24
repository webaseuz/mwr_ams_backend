using MediatR;

namespace AutoPark.Application.UseCases.Currencies;

public class GetCurrencyQueryHandler :
    IRequestHandler<GetCurrencyQuery, CurrencyDto>
{
    public Task<CurrencyDto> Handle(
        GetCurrencyQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new CurrencyDto());
}
