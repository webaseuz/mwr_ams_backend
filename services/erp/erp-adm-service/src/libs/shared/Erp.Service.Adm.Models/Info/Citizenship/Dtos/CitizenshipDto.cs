namespace Erp.Service.Adm.Models;

public class CitizenshipDto
{
    public int Id { get; set; }
    public string? WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsCitizenship { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<CitizenshipTranslateDto> Translates { get; set; } = new();
}
