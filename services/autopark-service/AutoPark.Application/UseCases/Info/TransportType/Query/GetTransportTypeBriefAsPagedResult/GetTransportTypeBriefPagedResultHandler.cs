using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TransportTypes;

public class GetTransportTypeBriefPagedResultHandler :
    IRequestHandler<GetTransportTypeBriefPagedResultQuery, PagedResultWithActionControls<TransportTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<TransportTypeBriefDto>> Handle(
        GetTransportTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportType, TransportTypeBriefDto>(_context.TransportTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportTypeCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class TransportTypeBriefDtoExtension
{
    public static async Task<IEnumerable<TransportTypeBriefDto>> SetActionControls(this IEnumerable<TransportTypeBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportTypeDelete));
        }

        return query;
    }
}
