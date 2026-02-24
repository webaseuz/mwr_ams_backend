
namespace AutoPark.Integration.Service.MapService;

public class OptimalRouteDto
{
    public Location StartLocation { get; set; } = new();
    public Location EndLocation { get; set; } = new();

    public List<Location> Directions { get; set; } = new();
}
