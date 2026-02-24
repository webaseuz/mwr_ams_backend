using AutoPark.Integration.Service.MapService;
using MediatR;

namespace AutoPark.Application.UseCases.Services.OptimalRouteService;


public class OptimalRouteQuery
    : OptimalRouteDto, IRequest<OptimalRouteDto>
{
}
