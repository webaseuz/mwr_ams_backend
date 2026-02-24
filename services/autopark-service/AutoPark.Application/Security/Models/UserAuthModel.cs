namespace AutoPark.Application;

public class UserAuthModel
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<string> Permissions { get; set; }
    public bool IsAdmin { get; set; }
    public int? LanguageId { get; set; }
    public string LanguageCode { get; set; }
    public string Pinfl { get; set; }
    public int? OrganizationId { get; set; }
    public int? BranchId { get; set; }
    public int? PositionId { get; set; }
    public long PersonId { get; set; }
    public UserAccess UserAccess { get; set; }
    public void ResolvePermissions()
    {
        if (IsAdmin)
            Permissions = Enum.GetNames(typeof(PermissionCode))
                            .ToHashSet();
    }

}

public class UserAccess
{
    public bool CanViewAllOrganizations { get; internal set; }
}
