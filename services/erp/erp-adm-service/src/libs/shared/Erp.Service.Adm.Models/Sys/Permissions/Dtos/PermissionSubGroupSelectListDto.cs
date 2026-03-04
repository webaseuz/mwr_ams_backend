namespace Erp.Service.Adm.Models;
public class PermissionSubGroupSelectListDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public IEnumerable<PermissionSelectListDto> Permissions { get; set; }

    // Shared permission fields
    public bool IsShared { get; set; }
    public int? SourceAppId { get; set; }
    public string SourceAppName { get; set; }
}
