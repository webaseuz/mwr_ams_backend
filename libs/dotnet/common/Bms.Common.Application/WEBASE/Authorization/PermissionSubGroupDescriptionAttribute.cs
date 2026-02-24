namespace Bms.WEBASE.Authorization
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PermissionSubGroupDescriptionAttribute : Attribute
    {
        public PermissionSubGroupDescriptionAttribute(int permissionGroupId, string shortName, string fullName)
        {
            PermissionGroupId = permissionGroupId;
            ShortName = shortName;
            FullName = fullName;
        }

        public PermissionSubGroupDescriptionAttribute(int groupId, string shortFullName)
            : this(groupId, shortFullName, shortFullName)
        {
        }

        public PermissionSubGroupDescriptionAttribute(int groupId)
            : this(groupId, null)
        {
        }

        public int PermissionGroupId { get; private set; }
        public string ShortName { get; private set; }
        public string FullName { get; set; }
        public string Code { get; set; }
    }

}
