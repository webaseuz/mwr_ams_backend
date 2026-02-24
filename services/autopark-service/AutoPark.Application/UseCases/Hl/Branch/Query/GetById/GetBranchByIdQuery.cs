using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchByIdQuery :
    IRequest<BranchDto>
{
    public int Id { get; set; }
}
