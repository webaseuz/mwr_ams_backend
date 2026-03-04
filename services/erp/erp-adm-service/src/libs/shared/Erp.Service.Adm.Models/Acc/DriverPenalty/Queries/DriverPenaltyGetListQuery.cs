using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class DriverPenaltyGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<DriverPenaltyBriefDto>>
{
    public int? RegionId { get; set; }
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
    public int? TransportId { get; set; }
    public string RegistrationNumber { get; set; }
    public DateTime? ExpireFromDate { get; set; }
    public DateTime? ExpireToDate { get; set; }
}
