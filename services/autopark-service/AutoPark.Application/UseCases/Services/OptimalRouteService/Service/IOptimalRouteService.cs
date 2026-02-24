using AutoPark.Integration.Service.MapService;

namespace AutoPark.Application.UseCases.Services.OptimalRouteService;

public interface IOptimalRouteService
{
    Task<OptimalRouteDto> GetDirectionResponseAsync(OptimalRouteDto dto);
}
