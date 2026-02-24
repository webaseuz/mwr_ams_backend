using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Districts;

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
    {
        var query = _context.Districts.IsSoftActive();

        if (request.RegionId.HasValue)
        {
            query = query.Where(x => x.RegionId == request.RegionId.Value);
        }

        return await query.AsSelectList(cancellationToken);
    }
    //    => await _context.Districts
    //                .IsSoftActive()
    //                .Where(x => !request.RegionId.HasValue || x.RegionId == request.RegionId)
    //                .AsSelectList(cancellationToken);
}
