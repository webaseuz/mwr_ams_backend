using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.PresentNotifications;

public class GetPresentNotificationBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<PresentNotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? UserId { get; set; }
}
