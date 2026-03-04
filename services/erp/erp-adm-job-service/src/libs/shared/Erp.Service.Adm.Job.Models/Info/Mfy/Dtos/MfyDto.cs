namespace Erp.Service.Adm.Job.Models;
public class MfyDto
{
    public int Id { get; set; }
    public string Inn { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public int RegionId { get; set; }
    public string District { get; set; }
    public string Region { get; set; }
    public int DistrictId { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public string Soato { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
