namespace Erp.Core.Security;

public interface IUserAuthModel
{
    int Id { get; set; }
    string Inn { get; set; }
    string UserName { get; set; }
    string FullName { get; set; }
    IEnumerable<string> Permissions { get; set; }
    IEnumerable<string> SharedPermissions { get; set; }
    bool IsAdmin { get; set; }
    int? LanguageId { get; set; }
    string LanguageCode { get; set; }
    string Pinfl { get; set; }
    int PersonId { get; set; }
    public int? BranchId { get; set; }
    public int? PositionId { get; set; }
    List<IOrganizationAuthModel> Organizations { get; set; }
    List<IRegionAuthModel> Regions { get; set; }
    void ResolveModules();
}
