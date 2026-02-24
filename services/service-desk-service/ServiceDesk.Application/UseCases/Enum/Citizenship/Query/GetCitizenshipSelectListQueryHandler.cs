using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class GetCitizenshipSelectListQueryHandler
	: IRequestHandler<GetCitizenshipSelectListQuery, SelectList<int>>
{
	private readonly IReadEfCoreContext _context;

	public GetCitizenshipSelectListQueryHandler(IReadEfCoreContext context)
	{
		_context = context;
	}

	public async Task<SelectList<int>> Handle(GetCitizenshipSelectListQuery request,
											   CancellationToken cancellationToken)
		=> await _context.Citizenships
				.AsSelectList(cancellationToken);
}
