namespace Erp.Service.Adm.Models;

public class PermissionGroupSelectListDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionSubGroupSelectListDto> SubGroups { get; set; }
}

public class PermissionSubGroupSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionItemSelectListDto> Permissions { get; set; }
}

public class PermissionItemSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
}