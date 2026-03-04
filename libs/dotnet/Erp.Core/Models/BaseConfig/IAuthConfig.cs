namespace Erp.Core;

public enum AuthenticationType
{
    Basic,
    Bearer,
    ApiKey,
    Custom
}

public interface IAuthConfig
{
    string Api { get; }
    AuthenticationType AuthType { get; }
    int TimeoutSeconds { get; }
}
