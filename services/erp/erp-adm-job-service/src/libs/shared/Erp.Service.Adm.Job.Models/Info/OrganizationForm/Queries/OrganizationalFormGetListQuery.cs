using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationalFormGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<OrganizationFormBriefDto>>
{
}
