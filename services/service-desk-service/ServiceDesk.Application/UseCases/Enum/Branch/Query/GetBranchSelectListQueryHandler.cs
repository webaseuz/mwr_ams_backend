using ServiceDesk.Application.Security;
using Bms.WEBASE.Models;
using MediatR;
using Bms.Core.Application;

namespace ServiceDesk.Application.UseCases.Branches;

public class GetBranchSelectListQueryHandler :
    IRequestHandler<GetBranchSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
	public GetBranchSelectListQueryHandler(IReadEfCoreContext context,
                                           IAsyncAppAuthService authService)
    {
        _context = context;
        _authService = authService;
    }
    public async Task<SelectList<int>> Handle(GetBranchSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Branches
                    .IsSoftActive()
                    .AsSelectList(request, _authService, cancellationToken);
}
