using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankQueryHandler :
    IRequestHandler<GetBankQuery, BankDto>
{
    public Task<BankDto> Handle(
        GetBankQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new BankDto());
}
