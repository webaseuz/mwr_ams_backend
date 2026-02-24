using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelBriefPagedResultHandler :
    IRequestHandler<GetOilModelBriefPagedResultQuery, PagedResultWithActionControls<OilModelBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetOilModelBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<OilModelBriefDto>> Handle(
        GetOilModelBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<OilModel, OilModelBriefDto>(_context.OilModels);

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.OilModelCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}
public static class OilModelBriefDtoExtension
{
    public static async Task<IEnumerable<OilModelBriefDto>> SetActionControls(this IEnumerable<OilModelBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.OilModelView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.OilModelEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.OilModelDelete));
        }

        return query;
    }
}