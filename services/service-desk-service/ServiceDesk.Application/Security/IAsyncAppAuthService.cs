using WEBASE.Security.Abstraction;

namespace ServiceDesk.Application.Security;

public interface IAsyncAppAuthService :
    IBaseAuthService
{
    Task<UserAuthModel> GetUserAsync();
    Task<OrganizationAuthModel> GetOrganizationAsync();
    Task<bool> HasPermissionAsync(params PermissionCode[] permissionCodes);
}