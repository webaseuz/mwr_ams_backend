using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Positions;

public class PositionSelectListQueryHandler :
        IRequestHandler<PositionSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public PositionSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(PositionSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.Positions
                .AsSelectList(cancellationToken);
}
