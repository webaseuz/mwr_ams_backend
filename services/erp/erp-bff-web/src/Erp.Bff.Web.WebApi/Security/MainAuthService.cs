using Erp.Adm.Bff.Web.Application;
using Erp.Core.Extensions;
using Erp.Service.Adm.Sdk;

namespace Erp.Adm.Bff.Web.WebApi;

public class MainAuthService : IMainAuthService
{
    private readonly IHttpContextAccessor _accessor;
    private readonly ISystemApi _systemApi;
    public MainAuthService(IHttpContextAccessor accessor, ISystemApi systemApi)
    {
        _accessor = accessor;
        _systemApi = systemApi; 
    }

    public bool IsAuthenticated
    {
        get
        {
            var user = _accessor.HttpContext?.User;
            return user != null && user.Identity != null && user.Identity.IsAuthenticated;
        }
    }

    public string UserName => _accessor.HttpContext?.User?.GetKeycloakUsername() ?? string.Empty;

    public string UserIdentityName => UserName;

    public object UserIdentity => throw new NotImplementedException();

    public Task<bool> HasAnyPermissionAsync(string[] permissionCodes)
    {
        throw new NotImplementedException();
    }
}
