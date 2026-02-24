using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorSelectListQueryHandler :
    IRequestHandler<GetTransportColorSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportColorSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTransportColorSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TransportColors
                    .AsSelectList(cancellationToken);
}
