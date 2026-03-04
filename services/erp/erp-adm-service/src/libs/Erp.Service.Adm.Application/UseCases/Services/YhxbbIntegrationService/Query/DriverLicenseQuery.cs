using Erp.Integration.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class DriverLicenseQuery : DriverLicenseRequestDto, IRequest<DriverLicenseResponseDto>
{
}
