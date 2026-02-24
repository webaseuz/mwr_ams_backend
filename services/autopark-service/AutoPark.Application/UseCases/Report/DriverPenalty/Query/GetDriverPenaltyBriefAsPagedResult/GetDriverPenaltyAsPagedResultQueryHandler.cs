using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.DriverPenalties;

public class GetDriverPenaltyAsPagedResultQueryHandler :
    IRequestHandler<GetDriverPenaltyBriefAsPagedResultQuery, PagedResult<DriverPenaltyBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetDriverPenaltyAsPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResult<DriverPenaltyBriefDto>> Handle(
        GetDriverPenaltyBriefAsPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<DriverPenalty, DriverPenaltyBriefDto>(_context.DriverPenalties);

        query = await query
            .FilterByUserInput(request)
            .SortFilter(request)
            .FilterByPermissions(_authService);

        var res = await query.AsPagedResultAsync(request, cancellationToken);

        foreach (var dto in res.Rows)
        {
            dto.CanPay = (await _authService.GetPermissionsAsync()).Contains(nameof(PermissionCode.DriverPenaltyPay));
        }

        return res;
    }
}
