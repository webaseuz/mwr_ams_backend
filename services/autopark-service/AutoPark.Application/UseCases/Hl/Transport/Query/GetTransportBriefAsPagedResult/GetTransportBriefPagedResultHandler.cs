using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportBriefPagedResultHandler :
    IRequestHandler<GetTransportBriefPagedResultQuery, PagedResultWithActionControls<TransportBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetTransportBriefPagedResultHandler(
        IReadEfCoreContext context, IMapProvider mapper, IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<TransportBriefDto>> Handle(
        GetTransportBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Transport, TransportBriefDto>(_context.Transports.IsSoftActive());

        query = await query.SortFilter(request, _authService);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request, actionControls: actionControls, cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}


public static class TransportBriefDtoExtension
{
    public static async Task<IEnumerable<TransportBriefDto>> SetActionControls(this IEnumerable<TransportBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportDelete));
        }

        return query;
    }
}
