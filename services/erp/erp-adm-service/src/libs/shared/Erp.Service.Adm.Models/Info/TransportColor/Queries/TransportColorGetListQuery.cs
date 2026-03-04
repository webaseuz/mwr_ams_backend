using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportColorGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportColorBriefDto>>
{
    public int StateId { get; set; }
}
