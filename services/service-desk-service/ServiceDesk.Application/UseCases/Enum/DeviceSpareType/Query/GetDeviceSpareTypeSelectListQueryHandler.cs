using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceSpareTypes;

public class GetDeviceSpareTypeSelectListQueryHandler :
        IRequestHandler<GetDeviceSpareTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetDeviceSpareTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetDeviceSpareTypeSelectListQuery request, 
                                        CancellationToken cancellationToken)
    {
        if (request.FromTurnover)
            return await _context.DeviceSpareTypes
                            .IsSoftActive()
                            .AsSelectList(_context, request.BranchId, cancellationToken);
        else
            return await _context.DeviceSpareTypes
                            .IsSoftActive()
                            .AsSelectList(cancellationToken);
    } 
}
