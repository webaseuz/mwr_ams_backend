using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.WEBASE.Extensions;
using Bms.WEBASE.Models;
using MediatR;
using Bms.Core.Application.Models;
using ServiceDesk.Application.Security;

namespace ServiceDesk.Application.UseCases.Currencies;

public class GetCurrencyBriefPagedResultHandler :
    IRequestHandler<GetCurrencyBriefPagedResultQuery, PagedResultWithActionControls<CurrencyBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetCurrencyBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
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
		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

		return result;
    }
}
