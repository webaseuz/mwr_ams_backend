namespace Erp.Service.Adm.Job.Models;
public class TableDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public string DbTableName { get; set; }
    public string DbSchemaName { get; set; }
    public string TableType { get; set; }

    public List<FileConfigDto> FileConfigs { get; set; }
    public List<TableTranslateDto> Translates { get; set; } = new();
}
