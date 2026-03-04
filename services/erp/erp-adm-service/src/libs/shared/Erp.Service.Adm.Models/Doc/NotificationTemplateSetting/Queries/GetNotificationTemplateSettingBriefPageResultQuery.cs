using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class GetNotificationTemplateSettingBriefPageResultQuery : WbSortFilterPageOptions,
    IRequest<WbPagedResult<NotificationTemplateSettingBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
}
