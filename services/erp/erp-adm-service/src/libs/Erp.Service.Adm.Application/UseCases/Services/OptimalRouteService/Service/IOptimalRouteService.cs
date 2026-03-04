using Erp.Integration.Service.MapService;

namespace Erp.Service.Adm.Application.UseCases;

public interface IOptimalRouteService
{
    Task<OptimalRouteDto> GetDirectionResponseAsync(OptimalRouteDto dto);
}
