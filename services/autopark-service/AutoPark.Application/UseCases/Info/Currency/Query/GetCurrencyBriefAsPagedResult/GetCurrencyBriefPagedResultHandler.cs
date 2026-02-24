using AutoPark.Application.Security;
using AutoPark.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;

namespace AutoPark.Application.UseCases.Currencies;

public class GetCurrencyBriefPagedResultHandler :
    IRequestHandler<GetCurrencyBriefPagedResultQuery, PagedResultWithActionControls<CurrencyBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    private readonly IAsyncAppAuthService _authService;
    public GetCurrencyBriefPagedResultHandler(
        IReadEfCoreContext context,
        IMapProvider mapper,
        IAsyncAppAuthService authService)
    {
        _context = context;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<PagedResultWithActionControls<CurrencyBriefDto>> Handle(
        GetCurrencyBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Currency, CurrencyBriefDto>(_context.Currencies.IsSoftActive());

        query = query.SortFilter(request);

        var actionControls = new PagedResultActionControl
        {
            CanCreate = await _authService.HasPermissionAsync(PermissionCode.CurrencyCreate)
        };

        return await query.AsPagedResultWithActionControlAsync(request, actionControls, cancellationToken);
    }
}
