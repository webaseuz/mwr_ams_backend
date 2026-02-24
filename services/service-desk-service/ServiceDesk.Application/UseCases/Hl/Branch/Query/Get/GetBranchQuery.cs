using MediatR;

namespace ServiceDesk.Application.UseCases.Branches;

public class GetBranchQuery :
    IRequest<BranchDto>
{ }
