using AutoPark.Integration.Models;
using MediatR;

namespace AutoPark.Application.UseCases;

public class VehicleLicenseQuery : VehicleLicenseRequestDto, IRequest<VehicleLicenseResponseDto>
{
}

