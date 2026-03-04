namespace Erp.Service.Adm.Models;

public class TireSizeDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Radius { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
