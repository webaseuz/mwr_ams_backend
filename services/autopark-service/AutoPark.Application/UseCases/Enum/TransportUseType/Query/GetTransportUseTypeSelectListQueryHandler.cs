using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportUseTypes;

public class GetTransportUseTypeSelectListQueryHandler :
    IRequestHandler<GetTransportUseTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportUseTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTransportUseTypeSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TransportUseTypes
                    .AsSelectList(request, cancellationToken);
}