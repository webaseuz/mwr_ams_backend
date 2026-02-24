using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankQuery :
    IRequest<BankDto>
{ }
