using MediatR;

namespace ServiceDesk.Application.UseCases.Banks;

public class GetBankByIdQuery :
    IRequest<BankDto>
{
    public int Id { get; set; }
}
