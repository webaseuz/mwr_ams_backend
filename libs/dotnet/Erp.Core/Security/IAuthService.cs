using WEBASE;

namespace Erp.Core.Security;

public interface IAuthService : IWbAuthService
{
    string UserIp { get; }

    string UserAgent { get; }

    object UserId { get; }

    string UserName { get; }

    HashSet<string> Modules { get; }

    bool HasPermission(string moduleCode);

    int CurrentOrganizationId { get; }

    IOrganizationAuthModel CurrentOrganization { get; }

    IUserAuthModel User { get; }
}
