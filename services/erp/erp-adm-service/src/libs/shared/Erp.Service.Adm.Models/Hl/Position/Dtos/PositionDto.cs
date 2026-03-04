namespace Erp.Service.Adm.Models;

public class PositionDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string? OrderCode { get; set; }
    public int StateId { get; set; }
    public List<PositionTranslateDto> Translates { get; set; } = new();
}
