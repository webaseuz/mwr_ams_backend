using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class PresentNotificationGetListQuery : WbSortFilterPageOptions, IRequest<WbPagedResult<PresentNotificationBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? UserId { get; set; }
}
