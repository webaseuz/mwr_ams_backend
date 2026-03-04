namespace Erp.Service.Adm.Models;

public class RegionBriefDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string? Code { get; set; }
    public string? Soato { get; set; }
    public string? RoamingCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
}
