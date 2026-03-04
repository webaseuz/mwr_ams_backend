using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Job.Models;
public class OrganizationPrintAsExcelCommand : WbSortFilterPageOptions,
    IRequest<byte[]>
{
    public int? StateId { get; set; }
    public int? DistrictId { get; set; }
    public int? RegionId { get; set; }
    public int? InstitutionTypeId { get; set; }
    public int? OrganizationTypeId { get; set; }
}
