using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class GetServiceTypeSelectListQueryHandler :
        IRequestHandler<GetServiceTypeSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    public GetServiceTypeSelectListQueryHandler(IReadEfCoreContext context)
    {
        _context = context;
    }
    public async Task<SelectList<int>> Handle(GetServiceTypeSelectListQuery request, 
                                        CancellationToken cancellationToken)
        => await _context.ServiceTypes
                    .IsSoftActive()
                    .Where(st => !request.DeviceTypeId.HasValue || request.DeviceTypeId == st.DeviceTypeId || st.DeviceTypeId == null)
					.AsSelectList(cancellationToken);   
}
