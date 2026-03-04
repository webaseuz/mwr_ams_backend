using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CustomJobGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<CustomJobBriefDto>>
{
    public List<int?> StatusIds { get; set; }
    public int? OrganizationId { get; set; }
    public int? RegionId { get; set; }
    public int? DistrictId { get; set; }

    public List<int?> PrevStatusIds { get; set; }
    public int? JobTypeId { get; set; }
}
