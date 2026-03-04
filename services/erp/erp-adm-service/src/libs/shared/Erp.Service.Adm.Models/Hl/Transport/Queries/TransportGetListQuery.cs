using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class TransportGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<TransportBriefDto>>
{
    public int? BranchId { get; set; }
}
