namespace Erp.Service.Adm.Job.Models;
public class InstitutionTypeDto
{
    public int Id { get; set; }
    public string OrderCode { get; set; }
    public string Code { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int OrganizationTypeId { get; set; }
    public string OrganizationName { get; set; }
    public string FinalYear { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<InstitutionTypeTranslateDto> Translates { get; set; } = new List<InstitutionTypeTranslateDto>();
}
