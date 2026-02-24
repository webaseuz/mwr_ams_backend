using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Enum.QrCodeTypes;

public class GetQrCodeTypeSelectListQueryHandler :
      IRequestHandler<GetQrCodeTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetQrCodeTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }

    public async Task<SelectList<int>> Handle(GetQrCodeTypeSelectListQuery reques,
                                                    CancellationToken cancellationToken)
       => await _context.QrCodeTypes
        .AsSelectList(cancellationToken);
}
