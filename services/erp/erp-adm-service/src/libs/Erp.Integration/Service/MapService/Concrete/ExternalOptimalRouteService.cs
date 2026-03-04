using Erp.Integration.Service.MapService;

namespace Erp.Integration.Service.MapService.Concrete;

public class ExternalOptimalRouteService : IExternalOptimalRouteService
{
    public Task<OptimalRouteDto> GetOptimalRouteAsync(OptimalRouteDto request)
    {
        throw new NotImplementedException();
        //Yandex yoki Google ga ulanganda shu yerda logika yoziladi
    }
}
