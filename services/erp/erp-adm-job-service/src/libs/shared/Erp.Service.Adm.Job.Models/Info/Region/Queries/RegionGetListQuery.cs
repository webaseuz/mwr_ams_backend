using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class RegionGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<RegionBriefDto>>
{
    public int StateId { get; set; }
}
