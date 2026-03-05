using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class RefuelGetBriefPageResultQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<RefuelBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
    public int? TransportId { get; set; }
}
