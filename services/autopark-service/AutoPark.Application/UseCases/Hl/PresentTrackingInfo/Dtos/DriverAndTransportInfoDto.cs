namespace AutoPark.Application.UseCases.PresentTrackingInfos;

public class DriverAndTransportInfoDto
{
    public string FullName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string StateNumber { get; set; } = string.Empty;
    public string TransportModel { get; set; } = string.Empty;
    public string TransportBrand { get; set; } = string.Empty;
    public int TransportColorId { get; set; }
    public string TransportColor { get; set; } = string.Empty;
}
