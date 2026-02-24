using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelSelectListQueryHandler :
    IRequestHandler<GetTransportModelSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportModelSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetTransportModelSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.TransportModels
                    .AsSelectList(request, cancellationToken);
}