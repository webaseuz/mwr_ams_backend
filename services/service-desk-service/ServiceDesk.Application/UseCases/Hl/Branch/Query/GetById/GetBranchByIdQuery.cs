using MediatR;

namespace ServiceDesk.Application.UseCases.Branches;

public class GetBranchByIdQuery :
    IRequest<BranchDto>
{
    public int Id { get; set; }
}
