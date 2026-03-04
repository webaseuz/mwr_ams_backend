using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class OrganizationGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<OrganizationBriefDto>>
{
    public int StateId { get; set; }
}
