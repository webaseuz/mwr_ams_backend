using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Notifications;

public class GetNotificationsByUserQuery :
    SortFilterPageOptions,
    IRequest<PagedResult<NotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
