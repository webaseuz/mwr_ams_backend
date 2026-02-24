using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Users;

public class GetUserSelectListQueryHandler :
    IRequestHandler<GetUserSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    public GetUserSelectListQueryHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _authService = authService;
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetUserSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.Users
            .IsSoftActive()
            .AsSelectList(request, _authService, cancellationToken);
}
