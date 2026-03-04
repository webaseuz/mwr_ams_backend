namespace Erp.Service.Adm.Models;

public class CustomJobActionDto
{
    public long Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string InputData { get; set; }
    public string ReturnData { get; set; }
    public bool IsSuccess { get; set; }
    public bool HasException { get; set; }
    public string Error { get; set; }
    public string UserMessage { get; set; }
    public bool FromCache { get; set; }
}
