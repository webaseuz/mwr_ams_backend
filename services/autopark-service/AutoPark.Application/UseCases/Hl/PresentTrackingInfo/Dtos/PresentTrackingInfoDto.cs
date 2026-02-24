namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class PresentTrackingInfoDto
{
    public long PersonId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
