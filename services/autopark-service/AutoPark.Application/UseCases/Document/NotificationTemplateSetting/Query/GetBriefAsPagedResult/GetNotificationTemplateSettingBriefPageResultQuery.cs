using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingBriefPageResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<NotificationTemplateSettingBriefDto>>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? BranchId { get; set; }
}
