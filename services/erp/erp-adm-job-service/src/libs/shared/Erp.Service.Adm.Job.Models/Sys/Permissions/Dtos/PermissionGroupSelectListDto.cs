namespace Erp.Service.Adm.Job.Models;
public class PermissionGroupSelectListDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string AppName { get; set; }
    public IEnumerable<PermissionSubGroupSelectListDto> SubGroups { get; set; }
}
