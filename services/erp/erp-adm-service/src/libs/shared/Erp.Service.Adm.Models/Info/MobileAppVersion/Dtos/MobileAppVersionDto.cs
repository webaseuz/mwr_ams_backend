namespace Erp.Service.Adm.Models;

public class MobileAppVersionDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string VersionCode { get; set; }
    public string Details { get; set; }
    public DateTime ReleaseAt { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
