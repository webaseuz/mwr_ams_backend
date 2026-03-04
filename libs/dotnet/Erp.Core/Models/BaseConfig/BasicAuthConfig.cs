namespace Erp.Core;

public class BasicAuthConfig : AuthConfigBase
{
    public override AuthenticationType AuthType => AuthenticationType.Basic;

    public string UserName { get; set; }
    public string Password { get; set; }
    public string BasicToken { get { return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{UserName}:{Password}")); } }
}
