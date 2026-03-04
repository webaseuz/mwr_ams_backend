using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class NotificationGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<NotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? UserId { get; set; }
}
