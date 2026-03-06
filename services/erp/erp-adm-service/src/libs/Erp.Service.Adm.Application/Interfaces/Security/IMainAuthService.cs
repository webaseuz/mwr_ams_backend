using Erp.Core;
using Erp.Core.Security;

namespace Erp.Service.Adm.Application;

public interface IMainAuthService : IAuthService
{
    int AppId { get; }
    public int? RequestedAppId { get; }
    bool HasPermission(params AdmPermissionCode[] permissionCodes);
    bool HasPermission(params AutoparkPermissionCode[] permissionCodes);
    void ResetUserName(string userName);
    void SetUser(IUserAuthModel user);
}
