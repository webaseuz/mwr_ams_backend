namespace Erp.Core;

public class CustomAuthConfig : AuthConfigBase
{
    public override AuthenticationType AuthType => AuthenticationType.Custom;

    public string CustomHeaderName { get; set; }
    public string CustomHeaderValue { get; set; }
}
