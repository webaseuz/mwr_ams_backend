using Erp.Integration.Service.MapService;
using Erp.Integration.Service.MapService.Concrete;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class OptimalRouteQueryHandler(
    IOptimalRouteService directionService,
    OptimalRouteConfig config,
    IExternalOptimalRouteService externalOptimalRouteService) : IRequestHandler<OptimalRouteQuery, OptimalRouteDto>
{
    public async Task<OptimalRouteDto> Handle(OptimalRouteQuery request, CancellationToken cancellationToken)
    {
        if (config.IsInternal)
            return await Task.Run(() => directionService.GetDirectionResponseAsync(request), cancellationToken);
        else
            return await Task.Run(() => externalOptimalRouteService.GetOptimalRouteAsync(request), cancellationToken);
    }
}
