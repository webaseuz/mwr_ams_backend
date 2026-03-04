using Erp.Core;
using Erp.Core.Models;

namespace Erp.Service.Adm.Models;
public class UserBriefDto : ISysEntity<int>
{
    public int Id { get; set; }
    public int TableId { get; } = TableIdConst.ADM_SYS_USER;
    public string OrderCode { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public int PersonId { get; set; }

    public int OrganizationId { get => UserOrganizations.FirstOrDefault()?.OrganizationId ?? 0; }
    public string OrganizationName { get => UserOrganizations.FirstOrDefault()?.OrganizationName; }

    public int RegionId { get => UserOrganizations.FirstOrDefault()?.RegionId ?? 0; }
    public string Region { get => UserOrganizations.FirstOrDefault()?.RegionName; }

    public int DistrictId { get => UserOrganizations.FirstOrDefault()?.DistrictId ?? 0; }
    public string District { get => UserOrganizations.FirstOrDefault()?.DistrictName; }

    public PersonBriefDto Person { get; set; }
    public List<UserRoleBriefDto> UserRoles { get; set; } = new();
    public List<UserOrganizationBriefDto> UserOrganizations { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public int? LastVisitAppId { get; set; }
    public string LastVisitApp { get; set; } = String.Empty;
    public DateTime? LastVisitAt { get; set; }
}
