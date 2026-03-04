namespace Erp.Core;

public class BearerAuthConfig : AuthConfigBase
{
    public override AuthenticationType AuthType => AuthenticationType.Bearer;

    public string BearerToken { get; set; }
}
