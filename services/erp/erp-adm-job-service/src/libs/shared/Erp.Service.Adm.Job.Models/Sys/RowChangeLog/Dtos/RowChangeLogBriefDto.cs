namespace Erp.Service.Adm.Job.Models;

public class RowChangeLogBriefDto
{
    public long Id { get; set; }
    public DateTime DateAt { get; set; }
    public string UserInfo { get; set; } = null!;
    public int TableId { get; set; }
    public int UserId { get; set; }
    public string Table { get; set; }
    public string IpAddress { get; set; } = null!;
    public string UserAgent { get; set; } = null!;
    public string Message { get; set; }
    public long RowId { get; set; }
}
