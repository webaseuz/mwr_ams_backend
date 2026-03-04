namespace Erp.Service.Adm.Job.Models;

public class CountryDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string SoatoCode { get; set; }
    public string RegionCode { get; set; }
    public string RoamingCode { get; set; }
    public string TextCode { get; set; }
    public string Icon { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<CountryTranslateDto> Translates { get; set; } = new List<CountryTranslateDto>();

}


