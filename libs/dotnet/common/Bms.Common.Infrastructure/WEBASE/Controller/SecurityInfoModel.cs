namespace Bms.WEBASE.Controller;

public class SecurityInfoModel
{
    public string Action { get; set; }

    public string Method { get; set; }

    public bool UnauthorizedAccess { get; set; }

    public HashSet<string> PermissionCodes { get; set; }

    public SecurityInfoModel()
    {
        PermissionCodes = new HashSet<string>();
    }
}
