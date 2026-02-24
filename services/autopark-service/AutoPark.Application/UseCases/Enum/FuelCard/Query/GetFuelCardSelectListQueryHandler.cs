using AutoPark.Application.Security;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.FuelCards;

public class GetFuelCardSelectListQueryHandler :
    IRequestHandler<GetFuelCardSelectListQuery, SelectList<int>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _appAuthService;

    public GetFuelCardSelectListQueryHandler(
        IReadEfCoreContext context,
        IAsyncAppAuthService appAuthService)
    {
        _context = context;
        _appAuthService = appAuthService;
    }

    public async Task<SelectList<int>> Handle(GetFuelCardSelectListQuery request,
                                        CancellationToken cancellationToken)
    {
        var query = _context.FuelCards.AsQueryable();

        await request.Init(_appAuthService);

        return await query.AsSelectList(request, cancellationToken);
    }
}
