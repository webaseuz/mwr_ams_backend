namespace Erp.Core;

public abstract class AuthConfigBase : IAuthConfig
{
    public string Api { get; set; } = string.Empty;
    public abstract AuthenticationType AuthType { get; }
    public int TimeoutSeconds { get; set; } = 30;
}
