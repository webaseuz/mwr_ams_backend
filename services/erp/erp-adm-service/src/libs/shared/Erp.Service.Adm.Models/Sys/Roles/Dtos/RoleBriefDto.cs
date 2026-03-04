namespace Erp.Service.Adm.Models;
public class RoleBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsAdmin { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
}
public class UserRoleBriefDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public bool IsAutomatic { get; set; }
}
