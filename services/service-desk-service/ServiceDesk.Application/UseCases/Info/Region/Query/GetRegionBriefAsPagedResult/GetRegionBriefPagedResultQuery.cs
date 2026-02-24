using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Regions;

public class GetRegionBriefPagedResultQuery :
	SortFilterPageOptions,
	IRequest<PagedResultWithActionControls<RegionBriefDto>>
{
}
