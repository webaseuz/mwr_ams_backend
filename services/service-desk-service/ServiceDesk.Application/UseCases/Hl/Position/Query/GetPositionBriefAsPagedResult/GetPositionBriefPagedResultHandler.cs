using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionBriefPagedResultHandler :
    IRequestHandler<GetPositionBriefPagedResultQuery, PagedResultWithActionControls<PositionBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetPositionBriefPagedResultHandler(IReadEfCoreContext context,
                                          IMapProvider mapper,
                                          IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _mapper = mapper;
        _appAuthService = appAuthService;
    }

    public async Task<PagedResultWithActionControls<PositionBriefDto>> Handle(
        GetPositionBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Position, PositionBriefDto>(_context.Positions.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _appAuthService.HasPermissionAsync(PermissionCode.PositionCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
