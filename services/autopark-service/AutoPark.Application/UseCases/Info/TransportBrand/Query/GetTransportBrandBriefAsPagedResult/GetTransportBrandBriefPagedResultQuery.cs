using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.TransportBrands;

public class GetTransportBrandBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<TransportBrandBriefDto>>
{
}
