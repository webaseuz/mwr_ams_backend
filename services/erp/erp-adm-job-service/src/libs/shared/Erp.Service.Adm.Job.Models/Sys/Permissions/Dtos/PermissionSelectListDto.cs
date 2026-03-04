namespace Erp.Service.Adm.Job.Models;
public class PermissionSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string SubGroupName { get; set; }
    public string FullName { get; set; }
    public string AppName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
