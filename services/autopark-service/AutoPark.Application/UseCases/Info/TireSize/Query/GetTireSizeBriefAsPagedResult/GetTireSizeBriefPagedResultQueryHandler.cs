using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.TireSizes;

public class GetTireSizeBriefPagedResultQueryHandler :
    IRequestHandler<GetTireSizeBriefPagedResultQuery, PagedResultWithActionControls<TireSizeBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetTireSizeBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<TireSizeBriefDto>> Handle(
        GetTireSizeBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<TireSize, TireSizeBriefDto>(_context.TireSizes.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.TireSizeCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request,
                                                               actionControls,
                                                               cancellationToken);
    }
}
