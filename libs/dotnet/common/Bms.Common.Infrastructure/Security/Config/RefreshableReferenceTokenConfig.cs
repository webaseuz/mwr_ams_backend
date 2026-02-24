namespace Bms.WEBASE.Security;

public class RefreshableReferenceTokenConfig :
    ReferenceTokenConfig
{
    public int RefreshExpire { get; set; }
}
