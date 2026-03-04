namespace Erp.Service.Adm.Job.Models;
public class RegionDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string SoatoCode { get; set; }
    public string RoamingCode { get; set; }
    public string RegionCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<RegionTranslateDto> Translates { get; set; } = new List<RegionTranslateDto>();

}
