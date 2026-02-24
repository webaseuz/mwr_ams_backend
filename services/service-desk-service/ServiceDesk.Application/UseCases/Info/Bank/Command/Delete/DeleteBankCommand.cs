using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Banks;

public class DeleteBankCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
