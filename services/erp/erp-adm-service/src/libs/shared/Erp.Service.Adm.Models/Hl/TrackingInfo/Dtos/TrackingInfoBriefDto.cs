namespace Erp.Service.Adm.Models;

public class TrackingInfoBriefDto
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public string PersonName { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DateAt { get; set; }
}
