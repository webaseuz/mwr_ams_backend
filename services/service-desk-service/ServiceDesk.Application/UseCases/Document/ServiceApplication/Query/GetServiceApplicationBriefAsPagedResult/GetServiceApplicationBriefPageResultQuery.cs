using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class GetServiceApplicationBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<ServiceApplicationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
}
