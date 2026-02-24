using Newtonsoft.Json;

namespace AutoPark.Integration.Models;

public class DriverPlaceModelDto
{
    public int RegionId { get; set; }

    public int CityId { get; set; }

    public string Place { get; set; }
}