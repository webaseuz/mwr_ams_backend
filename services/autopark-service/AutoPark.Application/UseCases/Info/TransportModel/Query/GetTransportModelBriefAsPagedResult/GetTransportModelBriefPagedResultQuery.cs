using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportModels;

public class GetTransportModelBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<TransportModelBriefDto>>
{
}
