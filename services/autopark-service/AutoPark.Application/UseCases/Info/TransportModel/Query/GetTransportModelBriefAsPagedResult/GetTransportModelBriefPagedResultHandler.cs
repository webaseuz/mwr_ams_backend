using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelBriefPagedResultHandler :
    IRequestHandler<GetTransportModelBriefPagedResultQuery, PagedResultWithActionControls<TransportModelBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetTransportModelBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<TransportModelBriefDto>> Handle(
        GetTransportModelBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TransportModel, TransportModelBriefDto>(_context.TransportModels.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TransportModelCreate)
        };

        var result = await query.AsPagedResultWithActionControlAsync(request,
                                                                     actionControls,
                                                                     cancellationToken);

        result.Rows = await result.Rows.SetActionControls(_authService);

        return result;
    }
}

public static class TransportModelBriefDtoExtension
{
    public static async Task<IEnumerable<TransportModelBriefDto>> SetActionControls(this IEnumerable<TransportModelBriefDto> query,
                                                                               IAsyncAppAuthService authService)
    {
        var permissions = await authService.GetPermissionsAsync();

        foreach (var ent in query)
        {
            ent.CanView = permissions.Contains(nameof(PermissionCode.TransportModelView));
            ent.CanModify = permissions.Contains(nameof(PermissionCode.TransportModelEdit));
            ent.CanDelete = permissions.Contains(nameof(PermissionCode.TransportModelDelete));
        }

        return query;
    }
}