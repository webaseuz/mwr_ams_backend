using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Branches;

public class GetBranchSelectListQueryHandler :
    IRequestHandler<GetBranchSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetBranchSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetBranchSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Branches
                    .IsSoftActive()
                    .AsSelectList(request, cancellationToken);
}
