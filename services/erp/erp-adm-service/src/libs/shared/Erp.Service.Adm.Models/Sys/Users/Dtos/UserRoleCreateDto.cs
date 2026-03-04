namespace Erp.Service.Adm.Models;

public class UserRoleCreateDto
{
    public int AppId { get; set; }
    public string AppName { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool IsAutomatic { get; set; }
}
