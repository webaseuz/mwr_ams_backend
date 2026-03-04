using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetUnreadNotificationCountQueryHandler : IRequestHandler<NotificationGetUnreadCountQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMainAuthService _authService;

    public GetUnreadNotificationCountQueryHandler(
        IApplicationDbContext context,
        IMainAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<int> Handle(NotificationGetUnreadCountQuery request, CancellationToken cancellationToken)
    {
        var userInfo = _authService.User;

        return await _context.Notifications
            .CountAsync(x => x.StateId == WbStateIdConst.ACTIVE && x.UserId == userInfo.Id && !x.IsRead, cancellationToken);
    }
}
