using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Info.LiquidTypes;

public class GetLiquidTypeBriefPagedResultQuery :
     SortFilterPageOptions,
     IRequest<PagedResultWithActionControls<LiquidTypeBriefDto>>
{
}
