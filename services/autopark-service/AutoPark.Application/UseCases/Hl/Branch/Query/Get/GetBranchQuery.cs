using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchQuery :
    IRequest<BranchDto>
{ }
