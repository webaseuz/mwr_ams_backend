namespace Bms.WEBASE.Security;

public class BasicAuthRealmConfig
{
    public string Realm { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string[] IpList { get; set; }
}
