using AutoMapper;
using Erp.Integration.Models;
using Erp.Integration.Service;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class VehicleSearchHandler(
    IYhxbbIntegrationService integrationService,
    IMapper mapper) : IRequestHandler<VehicleSearchQuery, VehicleInfoResponseDto>
{
    public async Task<VehicleInfoResponseDto> Handle(VehicleSearchQuery request, CancellationToken cancellationToken)
    {
        VehicleInfoResponse integrationDto;

        if (!string.IsNullOrEmpty(request.PlateNumber))
        {
            integrationDto = await integrationService.SearchVehicleByPlateNumberAsync(new VehicleSearchByPlateNumber
            {
                PlateNumber = request.PlateNumber
            });
        }
        else if (!string.IsNullOrEmpty(request.Pinfl))
        {
            integrationDto = await integrationService.SearchVehicleByPnflAsync(new VehicleSearchByPinfl
            {
                Pinfl = request.Pinfl
            });
        }
        else if (!string.IsNullOrEmpty(request.Tin))
        {
            integrationDto = await integrationService.SearchVehicleByTinAsync(new VehicleSearchByTin
            {
                Tin = request.Tin
            });
        }
        else
        {
            throw new ArgumentException("At least one search parameter must be provided.");
        }

        return mapper.Map<VehicleInfoResponseDto>(integrationDto);
    }
}
