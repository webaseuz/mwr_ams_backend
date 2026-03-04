namespace Erp.Service.Adm.Job.Models;
public class OrganizationTypeDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public long? CreatedBy { get; set; }
    public long? LastModifiedBy { get; set; }
    public List<OrganizationTypeTranslateDto> Translates { get; set; } = new List<OrganizationTypeTranslateDto>();

}
