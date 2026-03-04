namespace Erp.Service.Adm.Models;

public class DocumentFileDto
{
    public Guid Id { get; set; }
    public int TableId { get; set; }
    public int FileConfigId { get; set; }
    public int FileConfigTableId { get; set; }
    public string ColumnName { get; set; }
    public long FileSize { get; set; }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
}
