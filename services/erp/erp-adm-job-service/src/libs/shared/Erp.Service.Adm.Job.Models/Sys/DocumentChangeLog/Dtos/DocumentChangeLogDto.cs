namespace Erp.Service.Adm.Job.Models;

public class DocumentChangeLogDto
{
    public int UserId { get; set; }
    public DateTime DateAt { get; set; }
    public string UserInfo { get; set; } = null!;
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string Message { get; set; }
    public int TableId { get; set; }
    public long DocId { get; set; }
    public int StatusId { get; set; }

    public string Table { get; set; }
    public string Status { get; set; }
}
