using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleSelectListQueryHandler
	: IRequestHandler<GetRoleSelectListQuery, SelectList<int>>
{
	private readonly IReadEfCoreContext _context;

	public GetRoleSelectListQueryHandler(IReadEfCoreContext context)
	{
		_context = context;
	}

	public async Task<SelectList<int>> Handle(GetRoleSelectListQuery request,
											   CancellationToken cancellationToken)
		=> await _context.Roles
				.IsSoftActive()
				.AsSelectList(cancellationToken);
}
