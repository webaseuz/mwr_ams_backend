using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.OilModels;

public class GetOilModelBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<OilModelBriefDto>>
{
}
