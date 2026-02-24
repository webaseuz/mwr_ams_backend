using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Branches;

public class DeleteBranchCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
