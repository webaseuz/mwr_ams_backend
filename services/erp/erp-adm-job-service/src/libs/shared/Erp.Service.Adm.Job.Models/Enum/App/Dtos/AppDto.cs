namespace Erp.Service.Adm.Job.Models;

public class AppDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string AppUrl { get; set; }
    public string AppIcon { get; set; }
    public string Description { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<AppTranslateDto> Translates { get; set; } = new List<AppTranslateDto>();
}
