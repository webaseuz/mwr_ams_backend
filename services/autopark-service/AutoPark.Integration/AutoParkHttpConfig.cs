namespace AutoPark.Integration;

public class AutoParkHttpConfig
{
    public string Api { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string DriverLicenseApi {  get; set; } = string.Empty;
    public string VehicleLicenseApi {  get; set; } = string.Empty;
    public string VehicleInfoApi {  get; set; } = string.Empty;
    public bool UseStub { get; set; } 
}
