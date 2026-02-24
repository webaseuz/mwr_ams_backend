using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelSelectListQueryHandler
    : IRequestHandler<GetTireModelSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTireModelSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTireModelSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.TireModels
                .AsSelectList(cancellationToken);
}
