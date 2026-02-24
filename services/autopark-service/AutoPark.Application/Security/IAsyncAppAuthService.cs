using WEBASE.Security.Abstraction;

namespace AutoPark.Application.Security;

public interface IAsyncAppAuthService :
    IBaseAuthService
{
    Task<UserAuthModel> GetUserAsync();
    Task<UserAuthModel> GetUserAsync(string token);
    Task<OrganizationAuthModel> GetOrganizationAsync();
    Task<bool> HasPermissionAsync(params PermissionCode[] permissionCodes);
}