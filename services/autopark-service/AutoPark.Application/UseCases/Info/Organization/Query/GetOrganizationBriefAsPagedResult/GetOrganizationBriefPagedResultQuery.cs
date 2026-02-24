using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Organizations;

public class GetOrganizationBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<OrganizationBriefDto>>
{
}
