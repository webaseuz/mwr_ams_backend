using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelBriefPagedResultHandler :
    IRequestHandler<GetTireModelBriefPagedResultQuery, PagedResultWithActionControls<TireModelBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTireModelBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<TireModelBriefDto>> Handle(
        GetTireModelBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TireModel, TireModelBriefDto>(_context.TireModels);

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
public static class TireModelBriefDtoExtension
{
    public static async Task<IEnumerable<TireModelBriefDto>> SetActionControls(this IEnumerable<TireModelBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TireModelView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TireModelEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TireModelDelete));
        }

        return query;
    }
}