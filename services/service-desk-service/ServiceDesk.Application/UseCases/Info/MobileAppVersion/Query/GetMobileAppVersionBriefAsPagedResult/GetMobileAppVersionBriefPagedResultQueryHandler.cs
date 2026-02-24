using ServiceDesk.Application.Security;
using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class GetMobileAppVersionBriefPagedResultQueryHandler :
    IRequestHandler<GetMobileAppVersionBriefPagedResultQuery, PagedResultWithActionControls<MobileAppVersionBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetMobileAppVersionBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<MobileAppVersionBriefDto>> Handle(
        GetMobileAppVersionBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<MobileAppVersion, MobileAppVersionBriefDto>(_context.MobileAppVersions);

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.NationalityCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}
public static class MobileAppVersionBriefDtoExtension
{
    public static async Task<IEnumerable<MobileAppVersionBriefDto>> SetActionControls(this IEnumerable<MobileAppVersionBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.MobileAppVersionView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.MobileAppVersionEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.MobileAppVersionDelete));
        }

        return query;
    }
}