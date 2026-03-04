namespace Erp.Service.Adm.Job.Models;
public class UserAuthInfoDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int CurrentOrganizationId { get; set; }
    public string CurrentOrganizationName { get; set; }
    public List<string> Permissions { get; set; } = new List<string>();
    public List<UserAppDto> Apps { get; set; } = new();
}
