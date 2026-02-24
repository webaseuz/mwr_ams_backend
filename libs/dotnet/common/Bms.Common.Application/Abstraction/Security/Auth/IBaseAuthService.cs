namespace WEBASE.Security.Abstraction;

public interface IBaseAuthService
{
    /// <summary>
    /// JWT,System or Reference
    /// </summary>
    string AuthenticationType { get; }

    /// <summary>
    /// Check if user is authenticated or not
    /// </summary>
    /// <returns></returns>
    Task<bool> IsAuthenticatedAsync();

    /// <summary>
    /// Get user Id
    /// </summary>
    /// <returns></returns>
    Task<object> GetUserIdAsync();

    /// <summary>
    /// Get user identity (username , or email.Whatewer)
    /// </summary>
    /// <returns></returns>
    Task<string> GetUserIdentityAsync();

    /// <summary>
    /// Return Permissions HashSet<string>
    /// </summary>
    /// <returns></returns>
    Task<HashSet<string>> GetPermissionsAsync();

    /// <summary>
    /// Check user permissions if there is this kind of permissionCode
    /// </summary>
    /// <param name="permissionCode"></param>
    /// <returns></returns>
    Task<bool> HasPermissionAsync(string permissionCode);

    /// <summary>
    /// Reset userIdentity for manually authentication
    /// </summary>
    /// <param name="userIdentity"></param>
    void ResetUserIdentity(string userIdentity);

    /// <summary>
    /// Reset userIdentity for manually authentication using authenticationType 
    /// </summary>
    /// <param name="userIdentity"></param>
    /// <param name="authenticationType"></param>
    void ResetUserIdentity(string userIdentity,
                           string authenticationType);
}