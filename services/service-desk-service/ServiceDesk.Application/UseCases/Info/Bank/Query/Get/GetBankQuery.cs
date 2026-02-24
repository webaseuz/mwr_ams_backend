using MediatR;

namespace ServiceDesk.Application.UseCases.Banks;

public class GetBankQuery :
    IRequest<BankDto>
{ }
