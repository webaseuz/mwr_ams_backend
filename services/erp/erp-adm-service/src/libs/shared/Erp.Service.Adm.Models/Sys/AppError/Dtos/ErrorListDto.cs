namespace Erp.Service.Adm.Models;

public class ErrorListDto
{
    public long Id { get; set; }

    public string AppName { get; set; }

    public string UserId { get; set; }

    public string UserName { get; set; }

    public string TraceIdentifier { get; set; }

    public string Path { get; set; }

    public int StatusCode { get; set; }

    public string Type { get; set; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public string IpAddress { get; set; }

    public string UserAgent { get; set; }

    public string UserAgentOS { get; set; }

    public string UserAgentDevice { get; set; }

    public string UserAgentUA { get; set; }

    public string CorrelationId { get; set; }
}
