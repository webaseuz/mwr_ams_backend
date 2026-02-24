using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeBriefPagedResultHandler :
    IRequestHandler<GetOilTypeBriefPagedResultQuery, PagedResultWithActionControls<OilTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetOilTypeBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<OilTypeBriefDto>> Handle(
        GetOilTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<OilType, OilTypeBriefDto>(_context.OilTypes);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.OilTypeCreate)
        };

        query = query.SortFilter(request);

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
