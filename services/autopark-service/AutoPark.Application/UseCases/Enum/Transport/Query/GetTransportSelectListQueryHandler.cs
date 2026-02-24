using AutoPark.Application.Security;
using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.Transports;

public class GetTransportSelectListQueryHandler
 :
    IRequestHandler<GetTransportSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetTransportSelectListQueryHandler(IReadEfCoreContext context, IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _appAuthService = appAuthService;
    }
    public async Task<SelectList<int>> Handle(GetTransportSelectListQuery request,
                                        CancellationToken cancellationToken)
        => await _context.Transports.Include(t => t.Settings)
                    .IsSoftActive()
                    .AsSelectList(request, _appAuthService, cancellationToken);
}