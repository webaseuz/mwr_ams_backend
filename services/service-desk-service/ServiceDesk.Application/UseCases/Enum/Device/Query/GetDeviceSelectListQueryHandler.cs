using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Devices;

public class GetDeviceSelectListQueryHandler :
        IRequestHandler<GetDeviceSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;

    public GetDeviceSelectListQueryHandler(IReadEfCoreContext context,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<SelectList<int>> Handle(GetDeviceSelectListQuery request,
                                        CancellationToken cancellationToken)
    {
        await request.Init(_authService);

        return await _context.Devices
                    .IsSoftActive()
                    .AsSelectList(request, cancellationToken);
    }
}
