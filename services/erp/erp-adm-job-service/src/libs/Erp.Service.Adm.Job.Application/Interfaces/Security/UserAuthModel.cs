using Erp.Core;
using Erp.Core.Security;
using Newtonsoft.Json;

namespace Erp.Service.Adm.Job.Application;

public class UserAuthModel : IUserAuthModel
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<string> Permissions { get; set; } = new List<string>();
    public IEnumerable<string> SharedPermissions { get; set; } = new List<string>();
    public bool IsAdmin { get; set; }
    public int? LanguageId { get; set; }
    public string LanguageCode { get; set; }
    public string Pinfl { get; set; }
    public int PersonId { get; set; }
    public List<IOrganizationAuthModel> Organizations { get; set; }
    public List<IRegionAuthModel> Regions { get; set; }
    public int? CurrentOrganizationId { get; set; }
    public void ResolveModules()
    {
        List<string> mvdPermissions = MvdPermissions();
        List<string> uzasboPermissions = UzAsboPermissions();

        if (IsAdmin)
            Permissions = Enum.GetNames(typeof(AdmPermissionCode)).ToHashSet();
        else
        {
            Permissions = UserName.ToLower() switch
            {
                "dxm" => DxmPermissions(),
                "mvd" => mvdPermissions,
                "uzasbo" => uzasboPermissions,
                _ => Permissions
            };
        }
    }

    private static List<string> DxmPermissions()
    {
        return new List<string>
            {
                
            };
    }
    private static List<string> MvdPermissions()
    {
        var mvdPermissions = new List<string>
        {
            //Adm.JobPermissionCode.VioOrderCreate.ToString(),
            //Adm.JobPermissionCode.VioOrderView.ToString()
        };
        return mvdPermissions;
    }

    private static List<string> UzAsboPermissions()
    {
        var uzasboPermissions = new List<string>
            {
            };
        return uzasboPermissions;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
