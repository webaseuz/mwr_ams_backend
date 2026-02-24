using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.MovementTypes;

public class GetMovementTypeSelectListQueryHandler :
    IRequestHandler<GetMovementTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetMovementTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(
        GetMovementTypeSelectListQuery request, 
        CancellationToken cancellationToken)
        => await _context.MovementTypes
                        .AsSelectList(cancellationToken);
}
