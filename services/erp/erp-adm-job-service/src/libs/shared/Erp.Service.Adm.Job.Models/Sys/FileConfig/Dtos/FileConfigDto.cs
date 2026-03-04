namespace Erp.Service.Adm.Job.Models;
public class FileConfigDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int TableId { get; set; }
    public string Table { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int MaxSize { get; set; }
    public bool IsRequired { get; set; }
    public bool IsMultiple { get; set; }

    public int StateId { get; set; }
    public string State { get; set; }
    public List<FileConfigTableDto> Tables { get; set; } = new();
}
