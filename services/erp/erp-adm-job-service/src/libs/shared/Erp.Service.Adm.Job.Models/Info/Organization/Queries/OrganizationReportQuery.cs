using MediatR;

namespace Erp.Service.Adm.Job.Models;

public class OrganizationReportQuery : IRequest<List<OrganizationReportDto>>
{
    public int? RegionId { get; set; }
    public int? DistrictId { get; set; }
    public string SortBy { get; set; } = "name";
    public string OrderType { get; set; } = "asc";
}
