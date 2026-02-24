namespace Bms.WEBASE.Security;

public class JwtConfig : TokenConfig
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
}