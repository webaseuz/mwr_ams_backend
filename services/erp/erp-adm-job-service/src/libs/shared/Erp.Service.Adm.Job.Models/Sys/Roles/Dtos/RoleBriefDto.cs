namespace Erp.Service.Adm.Job.Models;
public class RoleBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsAdm.Jobin { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
}
public class UserRoleBriefDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
}
public class UserOrganizationBriefDto
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
}
