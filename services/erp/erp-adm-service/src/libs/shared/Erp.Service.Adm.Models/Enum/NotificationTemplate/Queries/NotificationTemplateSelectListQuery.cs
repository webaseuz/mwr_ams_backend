using MediatR;
using WEBASE;

namespace Erp.Service.Adm.Models;

public class NotificationTemplateSelectListQuery : IRequest<WbSelectList<long>>
{
}