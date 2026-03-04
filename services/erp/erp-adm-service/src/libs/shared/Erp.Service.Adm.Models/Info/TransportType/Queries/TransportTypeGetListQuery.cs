using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportTypeBriefDto>>
{
    public int StateId { get; set; }
}
