using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Enum.Statuses;

public class GetStatusSelectListQueryHandler :

     IRequestHandler<GetStatusSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetStatusSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetStatusSelectListQuery request,
                                               CancellationToken cancellationToken)
            => await _context.Statuses
                    .AsSelectList(cancellationToken);
}
