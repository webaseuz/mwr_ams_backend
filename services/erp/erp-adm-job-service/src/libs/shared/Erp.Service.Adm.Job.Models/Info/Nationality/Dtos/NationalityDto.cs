namespace Erp.Service.Adm.Job.Models;
public class NationalityDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string TextCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public List<NationalityTranslateDto> Translates { get; set; } = new List<NationalityTranslateDto>();

}
