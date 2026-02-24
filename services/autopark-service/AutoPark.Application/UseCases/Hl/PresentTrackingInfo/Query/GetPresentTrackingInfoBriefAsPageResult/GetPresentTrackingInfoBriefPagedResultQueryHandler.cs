using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application.Mapping;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class GetPresentTrackingInfoBriefPagedResultQueryHandler :
    IRequestHandler<GetPresentTrackingInfoBriefPagedResultQuery, IEnumerable<PresentTrackingInfoBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;

    public GetPresentTrackingInfoBriefPagedResultQueryHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<IEnumerable<PresentTrackingInfoBriefDto>> Handle(GetPresentTrackingInfoBriefPagedResultQuery request, CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<PresentTrackingInfo, PresentTrackingInfoBriefDto>(_context.PresentTrackingInfos);

        query = query.SortFilter(request);

        return await query.ToListAsync();
    }
}
