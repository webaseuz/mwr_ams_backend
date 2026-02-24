using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandBriefPagedResultHandler :
    IRequestHandler<GetTransportBrandBriefPagedResultQuery, PagedResultWithActionControls<TransportBrandBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetTransportBrandBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<TransportBrandBriefDto>> Handle(
        GetTransportBrandBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportBrand, TransportBrandBriefDto>(_context.TransportBrands.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportBrandCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class TransportBrandBriefDtoExtension
{
    public static async Task<IEnumerable<TransportBrandBriefDto>> SetActionControls(this IEnumerable<TransportBrandBriefDto> query,

        IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportBrandView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportBrandEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportBrandDelete));
        }

        return query;
    }
}
