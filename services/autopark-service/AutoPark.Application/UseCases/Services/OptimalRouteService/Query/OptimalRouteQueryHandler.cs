using AutoPark.Integration.Service.MapService;
using AutoPark.Integration.Service.MapService.Concrete;
using MediatR;

namespace AutoPark.Application.UseCases.Services.OptimalRouteService;

public class OptimalRouteQueryHandler
    : IRequestHandler<OptimalRouteQuery, OptimalRouteDto>
{
    private readonly IOptimalRouteService _directionService;
    private OptimalRouteConfig _config;
    private readonly IExternalOptimalRouteService _externalOptimalRouteService;

    public OptimalRouteQueryHandler(IOptimalRouteService directionService,
                                    OptimalRouteConfig config,
                                    IExternalOptimalRouteService externalOptimalRouteService)
    {
        _directionService = directionService;
        _config = config;
        _externalOptimalRouteService = externalOptimalRouteService;
    }

    public async Task<OptimalRouteDto> Handle(OptimalRouteQuery request,
                                 CancellationToken cancellationToken)
    {
        if (_config.IsInternal)
            return await Task.Run(() => _directionService.GetDirectionResponseAsync(request), cancellationToken);
        else
            return await Task.Run(() => _externalOptimalRouteService.GetOptimalRouteAsync(request), cancellationToken);
    }
}
