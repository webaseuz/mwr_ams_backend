using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportUseTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportUseTypeBriefDto>>
{
    public int StateId { get; set; }
}
