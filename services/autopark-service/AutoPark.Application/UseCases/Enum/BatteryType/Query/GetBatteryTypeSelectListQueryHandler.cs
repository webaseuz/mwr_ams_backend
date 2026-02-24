using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.BatteryTypes;

public class GetBatteryTypeSelectListQueryHandler :
    IRequestHandler<GetBatteryTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetBatteryTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetBatteryTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.BatteryTypes
                    .IsSoftActive()
                    .AsSelectList(request, cancellationToken);
}
