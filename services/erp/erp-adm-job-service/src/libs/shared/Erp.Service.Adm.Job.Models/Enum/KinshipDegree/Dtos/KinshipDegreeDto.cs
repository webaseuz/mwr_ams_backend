namespace Erp.Service.Adm.Job.Models;

public class KinshipDegreeDto
{
    public int Id { get; set; }
    public string NameUz { get; set; }
    public string NameUzCyrl { get; set; }
    public string NameRu { get; set; }
    public string NameEn { get; set; }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}
