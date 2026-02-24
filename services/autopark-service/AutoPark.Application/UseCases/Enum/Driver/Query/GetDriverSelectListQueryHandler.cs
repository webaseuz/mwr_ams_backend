using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers;

public class GetDriverSelectListQueryHandler
 :
    IRequestHandler<GetDriverSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetDriverSelectListQueryHandler(IReadEfCoreContext context, IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _appAuthService = appAuthService;
    }
    public async Task<SelectList<int>> Handle(GetDriverSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Drivers
                    .IsSoftActive()
                    .AsSelectList(request, _appAuthService, cancellationToken);
}