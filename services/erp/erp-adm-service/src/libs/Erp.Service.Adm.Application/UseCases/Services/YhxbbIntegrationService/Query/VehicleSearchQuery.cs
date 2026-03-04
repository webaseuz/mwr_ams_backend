using Erp.Integration.Models;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

public class VehicleSearchQuery : VehicleSearchDto, IRequest<VehicleInfoResponseDto>
{
}
