using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class CancelNotificationTemplateSettingCommand : IRequest<WbHaveId<long>>
{
    public long Id { get; set; }
}
