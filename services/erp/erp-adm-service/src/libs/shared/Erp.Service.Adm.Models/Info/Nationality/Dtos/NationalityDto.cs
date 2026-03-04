namespace Erp.Service.Adm.Models;

public class NationalityDto
{
    public int Id { get; set; }
    public string? WbCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsNationality { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<NationalityTranslateDto> Translates { get; set; } = new();
}
