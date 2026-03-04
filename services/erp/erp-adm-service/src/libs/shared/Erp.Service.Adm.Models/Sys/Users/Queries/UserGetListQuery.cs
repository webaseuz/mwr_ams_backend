using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class UserGetListQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<UserBriefDto>>
{
    public int? StateId { get; set; }
    public int? DistrictId { get; set; }
    public int? RegionId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? OrganizationTypeId { get; set; }
    public int? OrganizationId { get; set; }
    public List<int> OrganizationIds { get; set; }
    public int? AppId { get; set; }
    public List<int?> RoleIds { get; set; }
}
