using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum.TransportTypes;

public class GetTransportTypeSelectListQueryHandler
    : IRequestHandler<GetTransportTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTransportTypeSelectListQuery request,
                                               CancellationToken cancellationToken)
        => await _context.TransportTypes
                .AsSelectList(cancellationToken);
}
