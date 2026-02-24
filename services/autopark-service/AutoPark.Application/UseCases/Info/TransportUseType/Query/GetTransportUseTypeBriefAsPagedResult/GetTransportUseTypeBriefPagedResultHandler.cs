using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeBriefPagedResultHandler :
    IRequestHandler<GetTransportUseTypeBriefPagedResultQuery, PagedResultWithActionControls<TransportUseTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportUseTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<TransportUseTypeBriefDto>> Handle(
        GetTransportUseTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportUseType, TransportUseTypeBriefDto>(_context.TransportUseTypes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportUseTypeCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class TransportUseTypeBriefDtoExtension
{
    public static async Task<IEnumerable<TransportUseTypeBriefDto>> SetActionControls(this IEnumerable<TransportUseTypeBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportUseTypeView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportUseTypeEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportUseTypeDelete));
        }

        return query;
    }
}