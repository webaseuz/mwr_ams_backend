namespace Erp.Service.Adm.Models;

public class PositionBriefDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
