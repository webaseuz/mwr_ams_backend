namespace AutoPark.Application.UseCases.TrackingInfos;

public class TrackingInfoDto
{
    public long PersonId { get; set; }
    public string PersonName { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DateAt { get; set; }
}
