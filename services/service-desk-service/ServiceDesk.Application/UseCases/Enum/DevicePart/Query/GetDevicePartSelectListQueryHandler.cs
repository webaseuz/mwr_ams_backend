using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceParts;

public class GetDevicePartSelectListQueryHandler :
        IRequestHandler<GetDevicePartSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetDevicePartSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetDevicePartSelectListQuery request,
                                        CancellationToken cancellationToken)
    {
        return await _context.DeviceParts
                    .IsSoftActive()
                    .Where(dp => !request.DeviceTypeId.HasValue || dp.DeviceTypeId == request.DeviceTypeId)
                    .AsSelectList(cancellationToken);
    }
}
