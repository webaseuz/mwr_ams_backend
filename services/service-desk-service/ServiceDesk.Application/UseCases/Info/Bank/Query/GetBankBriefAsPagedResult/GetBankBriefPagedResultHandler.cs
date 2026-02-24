using Bms.Core.Application;
using Bms.Core.Application.Mapping;
using Bms.Core.Application.Models;
using Bms.WEBASE.Extensions;
using MediatR;
using ServiceDesk.Application.Security;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class GetBankBriefPagedResultHandler :
    IRequestHandler<GetBankBriefPagedResultQuery, PagedResultWithActionControls<BankBriefDto>>
{
    private readonly IReadEfCoreContext _context;
    private readonly IAsyncAppAuthService _authService;
    private readonly IMapProvider _mapper;

    public GetBankBriefPagedResultHandler(
        IAsyncAppAuthService authService,
        IReadEfCoreContext context,
        IMapProvider mapper)
    {
        _authService = authService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultWithActionControls<BankBriefDto>> Handle(
        GetBankBriefPagedResultQuery request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.MapCollection<Bank, BankBriefDto>(_context.Banks.IsSoftActive());

        query = query.SortFilter(request);

		var actionControls = new PagedResultActionControl
		{
			CanCreate = await _authService.HasPermissionAsync(PermissionCode.BankCreate)
		};
		var result = await query.AsPagedResultWithActionControlAsync(request,
																	 actionControls,
																	 cancellationToken);

		return result;
    }
}