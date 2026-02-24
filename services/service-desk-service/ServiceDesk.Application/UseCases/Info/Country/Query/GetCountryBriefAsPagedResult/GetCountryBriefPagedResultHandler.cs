using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Countries;

public class GetCountryBriefPagedResultHandler :
    IRequestHandler<GetCountryBriefPagedResultQuery, PagedResultWithActionControls<CountryBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;
    public GetCountryBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<CountryBriefDto>> Handle(
        GetCountryBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Country, CountryBriefDto>(_context.Countries.IsSoftActive());

        query = query.SortFilter(request);

		var actionControls = new PagedResultActionControl
		{
			CanCreate = await _authService.HasPermissionAsync(PermissionCode.CountryCreate)
		};

		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

		return result;
    }
}
