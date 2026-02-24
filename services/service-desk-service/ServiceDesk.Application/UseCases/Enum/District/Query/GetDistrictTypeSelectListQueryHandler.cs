using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Districts;

public class GetDistrictTypeSelectListQueryHandler :
    IRequestHandler<GetDistrictTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetDistrictTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetDistrictTypeSelectListQuery request,
                                              CancellationToken cancellationToken)
    => await _context.Districts
                .Where(x => !request.RegionId.HasValue || x.RegionId == request.RegionId)
                .AsSelectList(cancellationToken);
}
