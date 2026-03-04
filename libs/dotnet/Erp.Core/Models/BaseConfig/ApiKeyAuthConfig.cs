namespace Erp.Core;

public class ApiKeyAuthConfig : AuthConfigBase
{
    public override AuthenticationType AuthType => AuthenticationType.ApiKey;

    public string ApiKey { get; set; }
    public string ApiKeyHeaderName { get; set; } = "X-API-Key";
}
