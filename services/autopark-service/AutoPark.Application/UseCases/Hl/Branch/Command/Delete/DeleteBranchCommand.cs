using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class DeleteBranchCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
