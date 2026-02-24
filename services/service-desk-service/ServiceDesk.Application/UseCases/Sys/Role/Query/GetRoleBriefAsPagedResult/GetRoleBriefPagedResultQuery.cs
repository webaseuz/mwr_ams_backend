using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Roles;

public class GetRoleBriefPagedResultQuery :
	SortFilterPageOptions,
	IRequest<PagedResultWithActionControls<RoleBriefDto>>
{
}
