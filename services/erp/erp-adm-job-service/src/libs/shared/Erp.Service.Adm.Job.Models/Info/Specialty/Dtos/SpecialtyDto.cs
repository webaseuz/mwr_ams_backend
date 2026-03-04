namespace Erp.Service.Adm.Job.Models;
public class SpecialtyDto
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
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
