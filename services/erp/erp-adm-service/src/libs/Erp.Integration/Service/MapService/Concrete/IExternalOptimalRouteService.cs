using Erp.Integration.Service.MapService;

namespace Erp.Integration.Service.MapService.Concrete;

public interface IExternalOptimalRouteService
{
    Task<OptimalRouteDto> GetOptimalRouteAsync(OptimalRouteDto request);
}
