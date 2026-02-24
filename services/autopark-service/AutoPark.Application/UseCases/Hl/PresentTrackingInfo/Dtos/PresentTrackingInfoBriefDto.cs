namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class PresentTrackingInfoBriefDto
{
    public long Id { get; set; }
    public long PersonId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime CreatedAt { get; set; }
}
