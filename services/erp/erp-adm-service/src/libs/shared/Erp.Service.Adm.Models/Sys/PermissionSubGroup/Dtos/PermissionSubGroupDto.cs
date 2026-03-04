namespace Erp.Service.Adm.Models;
public class PermissionSubGroupDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int AppId { get; set; }
    public string AppName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public IEnumerable<PermissionSelectListDto> Permissions { get; set; }
}
