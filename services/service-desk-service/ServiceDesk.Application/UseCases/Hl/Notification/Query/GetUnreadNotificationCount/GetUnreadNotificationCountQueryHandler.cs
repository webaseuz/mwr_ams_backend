using ServiceDesk.Application.Security;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ServiceDesk.Application.UseCases.Notifications;

public class GetUnreadNotificationCountQueryHandler :
    IRequestHandler<GetUnreadNotificationCountQuery, int>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public GetUnreadNotificationCountQueryHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<int> Handle(GetUnreadNotificationCountQuery request,
                                  CancellationToken cancellationToken)
    {
        var userInfo = await _authService.GetUserAsync();
        var count = _context.Notifications.
                    Where(x => x.StateId == StateIdConst.ACTIVE && x.UserId == userInfo.Id && x.IsRead == false);

        return await count.CountAsync();
    }
}
