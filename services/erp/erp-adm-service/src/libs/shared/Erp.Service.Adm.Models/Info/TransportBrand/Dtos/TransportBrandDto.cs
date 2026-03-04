namespace Erp.Service.Adm.Models;

public class TransportBrandDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<TransportBrandTranslateDto> Translates { get; set; } = new();
}
