using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionSelectListQueryHandler
	: IRequestHandler<GetRegionSelectListQuery, SelectList<int>>
{
	private readonly IReadEfCoreContext _context;

	public GetRegionSelectListQueryHandler(IReadEfCoreContext context)
	{
		_context = context;
	}

	public async Task<SelectList<int>> Handle(GetRegionSelectListQuery request,
											   CancellationToken cancellationToken)
        => await _context.Regions
                .Where(x => !request.CountryId.HasValue || x.CountryId == request.CountryId)
                .AsSelectList(cancellationToken);
}
