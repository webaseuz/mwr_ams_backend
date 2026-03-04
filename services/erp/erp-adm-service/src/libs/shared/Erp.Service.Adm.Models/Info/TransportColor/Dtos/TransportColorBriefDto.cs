namespace Erp.Service.Adm.Models;

public class TransportColorBriefDto
{
    public int Id { get; set; }
    public string? OrderCode { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public int StateId { get; set; }
    public string? StateName { get; set; }
}
