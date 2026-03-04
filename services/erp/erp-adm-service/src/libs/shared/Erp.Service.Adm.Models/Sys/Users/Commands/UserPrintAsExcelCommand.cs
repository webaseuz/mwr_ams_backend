using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;
public class UserPrintAsExcelCommand : WbSortFilterPageOptions,
    IRequest<byte[]>
{
    public int? StateId { get; set; }
    public int? DistrictId { get; set; }
    public int? RegionId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? OrganizationTypeId { get; set; }
    public int? OrganizationId { get; set; }
    public int? AppId { get; set; }
    public List<int?> RoleIds { get; set; }
}
