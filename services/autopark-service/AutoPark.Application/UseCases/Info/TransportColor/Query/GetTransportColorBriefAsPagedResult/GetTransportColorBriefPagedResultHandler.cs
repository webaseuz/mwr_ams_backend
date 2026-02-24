using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorBriefPagedResultHandler :
    IRequestHandler<GetTransportColorBriefPagedResultQuery, PagedResultWithActionControls<TransportColorBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportColorBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;

    }

    public async Task<PagedResultWithActionControls<TransportColorBriefDto>> Handle(
        GetTransportColorBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportColor, TransportColorBriefDto>(_context.TransportColors.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportColorCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class TransportColorBriefDtoExtension
{
    public static async Task<IEnumerable<TransportColorBriefDto>> SetActionControls(this IEnumerable<TransportColorBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportColorView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportColorEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportColorDelete));
        }

        return query;
    }
}
