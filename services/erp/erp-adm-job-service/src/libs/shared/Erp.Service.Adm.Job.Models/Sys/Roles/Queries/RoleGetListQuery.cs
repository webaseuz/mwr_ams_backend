using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class RoleGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<RoleBriefDto>>
{
}
