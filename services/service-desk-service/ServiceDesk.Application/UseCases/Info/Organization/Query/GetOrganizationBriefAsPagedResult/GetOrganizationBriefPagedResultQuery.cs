using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Organizations;

public class GetOrganizationBriefPagedResultQuery :
	SortFilterPageOptions,
	IRequest<PagedResultWithActionControls<OrganizationBriefDto>>
{
}
