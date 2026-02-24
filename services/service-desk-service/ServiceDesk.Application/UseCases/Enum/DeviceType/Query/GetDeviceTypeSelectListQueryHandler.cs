using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceTypes;

public class GetDeviceTypeSelectListQueryHandler :
        IRequestHandler<GetDeviceTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetDeviceTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetDeviceTypeSelectListQuery request, 
                                        CancellationToken cancellationToken)
        => await _context.DeviceTypes
                    .AsSelectList(cancellationToken);   
}
