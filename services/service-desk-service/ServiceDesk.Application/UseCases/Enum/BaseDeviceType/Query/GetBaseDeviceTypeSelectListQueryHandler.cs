using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.BaseDeviceTypes;

public class GetBaseDeviceTypeSelectListQueryHandler :
    IRequestHandler<GetBaseDeviceTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetBaseDeviceTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetBaseDeviceTypeSelectListQuery request, 
                                        CancellationToken cancellationToken)
        => await _context.BaseDeviceTypes
					.AsSelectList(cancellationToken);
}
