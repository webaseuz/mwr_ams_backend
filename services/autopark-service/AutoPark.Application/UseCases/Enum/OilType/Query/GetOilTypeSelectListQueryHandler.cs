using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilTypes;

public class GetOilTypeSelectListQueryHandler
    : IRequestHandler<GetOilTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetOilTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetOilTypeSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.OilTypes
                .AsSelectList(cancellationToken);
}
