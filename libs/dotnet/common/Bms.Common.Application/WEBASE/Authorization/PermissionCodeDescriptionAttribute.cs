namespace Bms.WEBASE.Authorization;

[AttributeUsage(AttributeTargets.Field)]
public class PermissionCodeDescriptionAttribute : Attribute
{
    public PermissionCodeDescriptionAttribute(object permissionSubGroup,
                                              string shortName,
                                              string fullName)
    {
        PermissionSubGroup = permissionSubGroup;
        ShortName = shortName;
        FullName = fullName;
    }

    public PermissionCodeDescriptionAttribute(object permissionSubGroup,
                                              string shortFullName)
        : this(permissionSubGroup,
                shortFullName,
                shortFullName)
    { }

    public PermissionCodeDescriptionAttribute(object PermissionSubGroup)
        : this(PermissionSubGroup, null)
    { }

    public object PermissionSubGroup { get; private set; }
    public string FullName { get; private set; }
    public string ShortName { get; private set; }
    public string Code { get; set; }
}
