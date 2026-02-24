namespace Bms.WEBASE.Security;

public class RefreshableJwtConfig :
    JwtConfig
{
    public int RefreshExpire { get; set; }
}
