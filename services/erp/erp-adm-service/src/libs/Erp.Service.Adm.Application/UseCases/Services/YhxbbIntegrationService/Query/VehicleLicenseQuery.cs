using Erp.Integration.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class VehicleLicenseQuery : VehicleLicenseRequestDto, IRequest<VehicleLicenseResponseDto>
{
}
