using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetNotificationsByUserQueryHandler :
    IRequestHandler<GetNotificationsByUserQuery, PagedResult<NotificationBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetNotificationsByUserQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResult<NotificationBriefDto>> Handle(
        GetNotificationsByUserQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Notification, NotificationBriefDto>(_context.Notifications);
        query = await query.SortFilter(request, _authService);

        var result = await query.AsPagedResultAsync(request, cancellationToken);

        return result;
    }
}