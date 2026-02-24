using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TireModels;

public class GetTireModelBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<TireModelBriefDto>>
{
}
