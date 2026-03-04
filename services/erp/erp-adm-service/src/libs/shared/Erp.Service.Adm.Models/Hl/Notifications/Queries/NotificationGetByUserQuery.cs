using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class NotificationGetByUserQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<NotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
