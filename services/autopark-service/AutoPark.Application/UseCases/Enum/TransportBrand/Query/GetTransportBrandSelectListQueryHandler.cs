using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandSelectListQueryHandler :
    IRequestHandler<GetTransportBrandSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportBrandSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTransportBrandSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TransportBrands
                    .AsSelectList(cancellationToken);
}
