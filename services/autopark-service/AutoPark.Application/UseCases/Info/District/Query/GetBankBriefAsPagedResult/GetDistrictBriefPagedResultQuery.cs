using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Districts;

public class GetDistrictBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<DistrictBriefDto>>
{ }
