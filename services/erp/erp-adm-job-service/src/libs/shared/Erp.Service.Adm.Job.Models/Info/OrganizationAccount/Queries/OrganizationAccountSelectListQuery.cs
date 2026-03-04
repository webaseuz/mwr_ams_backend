using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationAccountSelectListQuery : IRequest<WbSelectList<int, OrganizationAccountSelectListDto>>
{
    public int? OrganizationId { get; set; }
    public int? RegionId { get; set; }
    public int? DistrictId { get; set; }
}
