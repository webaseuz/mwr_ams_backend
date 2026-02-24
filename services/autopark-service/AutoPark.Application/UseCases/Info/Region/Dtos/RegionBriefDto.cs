namespace AutoPark.Application.UseCases.Regions;

public class RegionBriefDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string Soato { get; set; }
    public string RoamingCode { get; set; }
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int StateId { get; private set; }
    public string StateName { get; private set; }
}
