namespace AutoPark.Integration.Service.MapService.Concrete;

public interface IExternalOptimalRouteService
{
    Task<OptimalRouteDto> GetOptimalRouteAsync(OptimalRouteDto request);
}
