using ServiceDesk.Application.UseCases.Enum.QrCodeStates;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.QrCodeStates;

public class GetQrCodeStateSelectListQueryHandler :
    IRequestHandler<GetQrCodeStateSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetQrCodeStateSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetQrCodeStateSelectListQuery reques,
                                                    CancellationToken cancellationToken)
         => await _context.QrCodeStates
        .AsSelectList(cancellationToken);
}
