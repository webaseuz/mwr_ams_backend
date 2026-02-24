using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelSelectListQueryHandler
    : IRequestHandler<GetOilModelSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetOilModelSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetOilModelSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.OilModels
                .Where(x => !request.OilTypeId.HasValue || x.OilTypeId == request.OilTypeId.Value)
                .AsSelectList(cancellationToken);
}
