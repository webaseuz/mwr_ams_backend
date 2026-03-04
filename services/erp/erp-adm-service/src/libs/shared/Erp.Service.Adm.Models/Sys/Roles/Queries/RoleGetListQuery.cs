using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class RoleGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<RoleBriefDto>>
{
    public int? AppId { get; set; }
    public int? StateId { get; set; }
}
