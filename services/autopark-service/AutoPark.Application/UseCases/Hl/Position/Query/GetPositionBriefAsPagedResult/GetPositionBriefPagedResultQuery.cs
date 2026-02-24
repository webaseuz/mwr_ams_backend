using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Positions;

public class GetPositionBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<PositionBriefDto>>
{
}
