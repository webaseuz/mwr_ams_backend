using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationSelectListQuery : IRequest<WbSelectList<int, OrganizationSelectListDto>>
{
    public int? StateId { get; set; }
    public bool? IsParent { get; set; }
    public int? OrganizationTypeId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? RegionId { get; set; }
    public int? DistrictId { get; set; }
}
