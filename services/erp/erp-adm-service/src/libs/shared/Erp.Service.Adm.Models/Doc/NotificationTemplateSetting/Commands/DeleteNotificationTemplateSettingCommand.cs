using MediatR;

namespace Erp.Service.Adm.Models;

public class DeleteNotificationTemplateSettingCommand : IRequest<bool>
{
    public long Id { get; set; }
}
