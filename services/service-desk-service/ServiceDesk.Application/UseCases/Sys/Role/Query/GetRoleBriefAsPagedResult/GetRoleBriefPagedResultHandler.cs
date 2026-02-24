using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using Bms.Core.Application.Models;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleBriefPagedResultHandler :
	IRequestHandler<GetRoleBriefPagedResultQuery, PagedResultWithActionControls<RoleBriefDto>>
{
	private readonly IReadEfCoreContext _context;
	private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetRoleBriefPagedResultHandler(IReadEfCoreContext context,
                                          IMapProvider mapper,
                                          IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<RoleBriefDto>> Handle(
        GetRoleBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Role, RoleBriefDto>(_context.Roles.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.RoleCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
