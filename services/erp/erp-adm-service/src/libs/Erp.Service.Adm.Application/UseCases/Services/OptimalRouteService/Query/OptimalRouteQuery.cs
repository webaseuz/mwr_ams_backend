using Erp.Integration.Service.MapService;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class OptimalRouteQuery : OptimalRouteDto, IRequest<OptimalRouteDto>
{
}
