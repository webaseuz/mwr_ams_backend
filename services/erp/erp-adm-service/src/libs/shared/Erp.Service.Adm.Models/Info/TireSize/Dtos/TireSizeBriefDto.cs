namespace Erp.Service.Adm.Models;

public class TireSizeBriefDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Radius { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
}
