using AutoMapper;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using WEBASE;
using WEBASE.AutoMapper;
using WEBASE.Culture;

namespace Erp.Service.Adm.Application.UseCases;

public class GetNotificationBriefPageResultHandler : IRequestHandler<NotificationGetListQuery, WbPagedResult<NotificationBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICultureHelper _cultureHelper;
    private readonly IMainAuthService _authService;

    public GetNotificationBriefPageResultHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ICultureHelper cultureHelper,
        IMainAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _cultureHelper = cultureHelper;
        _authService = authService;
    }

    public async Task<WbPagedResult<NotificationBriefDto>> Handle(NotificationGetListQuery request, CancellationToken cancellationToken)
    {
        var userInfo = _authService.User;
        var hasViewAll = userInfo.Permissions.Contains(nameof(PermissionCode.AllNotificationView));

        var query = _context.Notifications
            .MapTo<NotificationBriefDto>(_mapper, _cultureHelper);

        if (!hasViewAll)
            query = query.Where(x => x.StateId != WbStateIdConst.ACTIVE);

        if (request.UserId.HasValue)
            query = query.Where(x => x.UserId == request.UserId);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.CreatedAt >= request.FromDate);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.CreatedAt <= request.ToDate);

        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(x => x.Subject.ToLower().Contains(request.Search.ToLower()));

        return await query.AsPagedResultAsync(request, cancellationToken);
    }
}