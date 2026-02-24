using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchQueryHandler :
    IRequestHandler<GetBranchQuery, BranchDto>
{
    public Task<BranchDto> Handle(
        GetBranchQuery request,
        CancellationToken cancellationToken)
        => Task.FromResult(new BranchDto());
}