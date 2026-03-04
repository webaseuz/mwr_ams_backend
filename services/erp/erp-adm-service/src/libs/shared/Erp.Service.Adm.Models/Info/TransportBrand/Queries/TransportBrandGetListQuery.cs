using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportBrandGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportBrandBriefDto>>
{
    public int StateId { get; set; }
}
