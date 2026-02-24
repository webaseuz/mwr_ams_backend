using AutoPark.Integration.Models;
using MediatR;

namespace AutoPark.Application.UseCases;

public class DriverLicenseQuery : DriverLicenseRequestDto, IRequest<DriverLicenseResponseDto>
{
}

