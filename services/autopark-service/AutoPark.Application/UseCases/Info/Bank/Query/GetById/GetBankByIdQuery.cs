using MediatR;

namespace AutoPark.Application.UseCases.Banks;

public class GetBankByIdQuery :
    IRequest<BankDto>
{
    public int Id { get; set; }
}
