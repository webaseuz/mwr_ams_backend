using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class ContractorGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<ContractorBriefDto>>
{
    public int StateId { get; set; }
}
