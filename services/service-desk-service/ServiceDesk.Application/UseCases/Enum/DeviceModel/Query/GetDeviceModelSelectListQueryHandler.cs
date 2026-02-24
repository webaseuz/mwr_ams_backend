using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.DeviceModels;

public class GetDeviceModelSelectListQueryHandler :
        IRequestHandler<GetDeviceModelSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetDeviceModelSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetDeviceModelSelectListQuery request,
                                        CancellationToken cancellationToken)
    {
        return await _context.DeviceModels
                    .IsSoftActive()
                    .Where(dm => !request.DeviceTypeId.HasValue || dm.DeviceTypeId == request.DeviceTypeId)
                   .AsSelectList(cancellationToken);
    }
}
