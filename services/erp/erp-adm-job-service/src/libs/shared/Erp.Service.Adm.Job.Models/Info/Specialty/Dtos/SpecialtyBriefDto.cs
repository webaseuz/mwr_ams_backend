namespace Erp.Service.Adm.Job.Models;
public class SpecialtyBriefDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string OrderCode { get; set; }
    public string FullName { get; set; }
    public string ShortName { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public int DirectionId { get; set; }
    public string EduDirection { get; set; }
}
