using ServiceDesk.Domain;
using Bms.Core.Application.Mapping;
using Bms.Core.Application;
using MediatR;
using Bms.WEBASE.Models;
using Bms.WEBASE.Extensions;
using ServiceDesk.Application.Security;
using Bms.Core.Application.Models;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipBriefPagedResultQueryHandler :
    IRequestHandler<GetCitizenshipBriefPagedResultQuery, PagedResultWithActionControls<CitizenshipBriefDto>>
{
    private readonly IAsyncAppAuthService _authService;
    private readonly IReadEfCoreContext _context;
    private readonly IMapProvider _mapper;

    public GetCitizenshipBriefPagedResultQueryHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<CitizenshipBriefDto>> Handle(
        GetCitizenshipBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Citizenship, CitizenshipBriefDto>(_context.Citizenships.IsSoftActive());

        query = query.SortFilter(request);

		var actionControls = new PagedResultActionControl
		{
			CanCreate = await _authService.HasPermissionAsync(PermissionCode.CitizenshipCreate)
		};
		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

		return result;
    }
}
