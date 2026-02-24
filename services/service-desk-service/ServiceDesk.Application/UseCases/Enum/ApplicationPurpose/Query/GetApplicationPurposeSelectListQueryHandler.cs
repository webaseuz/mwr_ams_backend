using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ApplicationPurposes;

public class GetApplicationPurposeSelectListQueryHandler :
    IRequestHandler<GetApplicationPurposeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;

    public GetApplicationPurposeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetApplicationPurposeSelectListQuery request, 
                                        CancellationToken cancellationToken)
    {

       return await _context.ApplicationPurposes
                     .IsSoftActive()
                     .Where(dm => !request.DeviceTypeId.HasValue || dm.DeviceTypeId == request.DeviceTypeId)
                     .AsSelectList(cancellationToken);
    }
    
}
