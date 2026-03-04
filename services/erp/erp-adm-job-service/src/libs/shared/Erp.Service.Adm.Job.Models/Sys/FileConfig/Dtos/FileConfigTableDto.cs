namespace Erp.Service.Adm.Job.Models;
public class FileConfigTableDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int FileTypeId { get; set; }
    public string FileType { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
}
