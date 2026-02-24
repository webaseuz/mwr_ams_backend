using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

class GetDriverBriefPagedResultHandler :
    IRequestHandler<GetDriverBriefPagedResultQuery, PagedResultWithActionControls<DriverBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetDriverBriefPagedResultHandler(IReadEfCoreContext context,
                                          IMapProvider mapper,
                                          IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<DriverBriefDto>> Handle(
        GetDriverBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _mapper.MapCollection<Driver, DriverBriefDto>(_context.Drivers.IsSoftActive())
            .SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.DriverCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}


public static class DriverBriefDtoExtension
{
    public static async Task<IEnumerable<DriverBriefDto>> SetActionControls(this IEnumerable<DriverBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.DriverView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.DriverEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.DriverDelete));
        }

        return query;
    }
}