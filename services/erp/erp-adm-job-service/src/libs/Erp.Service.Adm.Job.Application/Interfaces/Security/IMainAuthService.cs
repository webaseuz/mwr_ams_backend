using Erp.Core;
using Erp.Core.Security;

namespace Erp.Service.Adm.Job.Application;

public interface IMainAuthService : IAuthService
{
    public int? RequestedAppId { get; }
    int AppId { get; }
    bool HasPermission(params AdmPermissionCode[] permissionCodes);
    void ResetUserName(string userName);
    void SetUser(IUserAuthModel user);
}
