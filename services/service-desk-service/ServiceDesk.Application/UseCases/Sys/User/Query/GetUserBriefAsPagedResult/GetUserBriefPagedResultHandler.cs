using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Users;

public class GetUserBriefPagedResultHandler :
    IRequestHandler<GetUserBriefPagedResultQuery, PagedResultWithActionControls<UserBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetUserBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }
    public async Task<PagedResultWithActionControls<UserBriefDto>> Handle(
        GetUserBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<User, UserBriefDto>(_context.Users.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.UserCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
