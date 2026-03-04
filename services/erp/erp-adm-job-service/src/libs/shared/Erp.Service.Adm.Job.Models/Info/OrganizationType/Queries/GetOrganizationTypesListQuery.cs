using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<OrganizationTypeBriefDto>>
{
    public int StateId { get; set; }
}
