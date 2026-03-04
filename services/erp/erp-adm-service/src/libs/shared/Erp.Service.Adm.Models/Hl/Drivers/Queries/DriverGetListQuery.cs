using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DriverGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DriverBriefDto>>
{
    public int? BranchId { get; set; }
}
