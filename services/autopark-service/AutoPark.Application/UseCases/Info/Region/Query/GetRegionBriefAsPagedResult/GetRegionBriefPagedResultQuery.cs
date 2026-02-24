using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Regions;

public class GetRegionBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<RegionBriefDto>>
{
}
