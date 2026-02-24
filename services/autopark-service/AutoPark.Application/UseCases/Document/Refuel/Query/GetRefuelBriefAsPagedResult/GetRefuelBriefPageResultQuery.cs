using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Refuels;

public class GetRefuelBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<RefuelBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
    public int? DriverId { get; set; }
    public int? TransportId { get; set; }
}
