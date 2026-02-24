using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportColors;

public class GetTransportColorBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<TransportColorBriefDto>>
{
}
