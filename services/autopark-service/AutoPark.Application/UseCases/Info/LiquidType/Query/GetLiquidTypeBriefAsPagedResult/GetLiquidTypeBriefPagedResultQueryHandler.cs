using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeBriefPagedResultQueryHandler :
    IRequestHandler<GetLiquidTypeBriefPagedResultQuery, PagedResultWithActionControls<LiquidTypeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetLiquidTypeBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<LiquidTypeBriefDto>> Handle(
        GetLiquidTypeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<LiquidType, LiquidTypeBriefDto>(_context.LiquidTypes.Where(a => a.StateId == StateIdConst.ACTIVE));

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.LiquidTypeCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
