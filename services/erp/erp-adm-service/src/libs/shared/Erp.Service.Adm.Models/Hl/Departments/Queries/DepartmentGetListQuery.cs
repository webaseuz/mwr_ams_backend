using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DepartmentGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DepartmentBriefDto>>
{
    public int? BranchId { get; set; }
}
