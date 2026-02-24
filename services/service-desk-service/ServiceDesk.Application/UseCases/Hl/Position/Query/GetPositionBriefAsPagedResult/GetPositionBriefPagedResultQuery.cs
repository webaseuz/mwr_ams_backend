using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Positions;

public class GetPositionBriefPagedResultQuery :
	SortFilterPageOptions,
	IRequest<PagedResultWithActionControls<PositionBriefDto>>
{
}
