using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeBriefPagedResultHandler :
    IRequestHandler<GetServiceTypeBriefPagedResultQuery, PagedResultWithActionControls<ServiceTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    private readonly IMapProvider _mapper;

    public GetServiceTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService authService,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<ServiceTypeBriefDto>> Handle(
        GetServiceTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<ServiceType, ServiceTypeBriefDto>(_context.ServiceTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.RegionCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
        result.Rows = await result.Rows.SetActionControls(_authService);
        return result;
    }
}
public static class ServiceTypeBriefDtoExtension
{
    public static async Task<IEnumerable<ServiceTypeBriefDto>> SetActionControls(this IEnumerable<ServiceTypeBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.ServiceTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.ServiceTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.ServiceTypeDelete));
        }

        return query;
    }
}
