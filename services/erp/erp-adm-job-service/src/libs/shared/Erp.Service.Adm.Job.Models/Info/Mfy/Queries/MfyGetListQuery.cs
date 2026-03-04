using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class MfyGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<MfyBriefDto>>
{
    public int? DistrictId { get; set; }
    public int? RegionId { get; set; }
    public int? StateId { get; set; }
}
