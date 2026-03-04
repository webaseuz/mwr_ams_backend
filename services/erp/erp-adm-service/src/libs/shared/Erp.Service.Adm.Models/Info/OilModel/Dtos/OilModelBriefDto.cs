namespace Erp.Service.Adm.Models;

public class OilModelBriefDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int OilTypeId { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
}
