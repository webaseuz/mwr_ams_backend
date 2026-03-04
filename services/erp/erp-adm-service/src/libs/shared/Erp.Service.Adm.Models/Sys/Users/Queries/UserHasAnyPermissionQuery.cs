using MediatR;

namespace Erp.Service.Adm.Models;
public class UserHasAnyPermissionQuery : IRequest<bool>
{
    public string UserName { get; set; }
    public string[] PermissionCodes { get; set; }
}
