namespace Erp.Service.Adm.Job.Models;
public class PermissionSubGroupSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionSelectListDto> Permissions { get; set; }
}
