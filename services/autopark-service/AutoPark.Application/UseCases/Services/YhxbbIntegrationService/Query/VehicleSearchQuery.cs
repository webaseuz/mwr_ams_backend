using AutoPark.Integration.Models;
using MediatR;

namespace AutoPark.Application.UseCases;

public class VehicleSearchQuery : VehicleSearchDto, IRequest<VehicleInfoResponseDto>
{
}
