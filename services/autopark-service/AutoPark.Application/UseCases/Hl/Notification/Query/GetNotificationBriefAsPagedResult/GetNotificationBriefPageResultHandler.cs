using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetNotificationBriefPageResultHandler :
    IRequestHandler<GetNotificationBriefPageResultQuery, PagedResultWithActionControls<NotificationBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetNotificationBriefPageResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<NotificationBriefDto>> Handle(
        GetNotificationBriefPageResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Notification, NotificationBriefDto>(_context.Notifications);
        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.NotificationCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        return result;
    }
}