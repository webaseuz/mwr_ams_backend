using AutoPark.Integration.Models;
using AutoPark.Integration.Models.Yhxbb.VehicleInfo;
using AutoPark.Integration.Service;
using Bms.Core.Application.Mapping;
using MediatR;

namespace AutoPark.Application.UseCases;

public class VehicleSearchHandler
    : IRequestHandler<VehicleSearchQuery, VehicleInfoResponseDto>
{
    private readonly IYhxbbIntegrationService _integrationService;
    private readonly IMapProvider _mapper;

    public VehicleSearchHandler(IYhxbbIntegrationService integrationService, IMapProvider mapper)
    {
        _integrationService = integrationService;
        _mapper = mapper;
    }

    public async Task<VehicleInfoResponseDto> Handle(VehicleSearchQuery request, CancellationToken cancellationToken)
    {
        VehicleInfoResponse integrationDto;

        if (!string.IsNullOrEmpty(request.PlateNumber))
        {
            integrationDto = await _integrationService.SearchVehicleByPlateNumberAsync(new VehicleSearchByPlateNumber
            {
                PlateNumber = request.PlateNumber
            });
        }
        else if (!string.IsNullOrEmpty(request.Pinfl))
        {
            integrationDto = await _integrationService.SearchVehicleByPnflAsync(new VehicleSearchByPinfl
            {
                Pinfl = request.Pinfl
            });
        }
        else if (!string.IsNullOrEmpty(request.Tin))
        {
            integrationDto = await _integrationService.SearchVehicleByTinAsync(new VehicleSearchByTin
            {
                Tin = request.Tin
            });
        }
        else
        {
            throw new ArgumentException("At least one search parameter must be provided.");
        }

        return _mapper
            .Map<VehicleInfoResponse, VehicleInfoResponseDto>(integrationDto);
    }
}

