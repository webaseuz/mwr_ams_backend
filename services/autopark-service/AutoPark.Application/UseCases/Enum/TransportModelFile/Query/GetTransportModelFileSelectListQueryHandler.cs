using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModelFiles;

public class GetTransportModelFileSelectListQueryHandler :
    IRequestHandler<GetTransportModelFileSelectListQuery, SelectList<Guid>>
{
    private readonly IReadEfCoreContext _context;

    public GetTransportModelFileSelectListQueryHandler(
        IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<Guid>> Handle(
        GetTransportModelFileSelectListQuery request,
        CancellationToken cancellationToken)
        => await _context.TransportModelFiles
                        .AsSelectList(request, cancellationToken);
}
