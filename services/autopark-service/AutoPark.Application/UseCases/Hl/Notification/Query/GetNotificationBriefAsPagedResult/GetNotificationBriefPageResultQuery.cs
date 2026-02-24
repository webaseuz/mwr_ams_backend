using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetNotificationBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<NotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? UserId { get; set; }
}
