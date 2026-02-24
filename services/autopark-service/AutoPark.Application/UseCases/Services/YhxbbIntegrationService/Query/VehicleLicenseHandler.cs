using AutoPark.Integration.Models;
using AutoPark.Integration.Models.Yhxbb.VehicleInfo;
using AutoPark.Integration.Service;
using Bms.Core.Application.Mapping;
using MediatR;

namespace AutoPark.Application.UseCases;

public class VehicleLicenseHandler
    : IRequestHandler<VehicleLicenseQuery, VehicleLicenseResponseDto>
{
    private readonly IYhxbbIntegrationService _integrationService;
    private readonly IMapProvider _mapper;

    public VehicleLicenseHandler(IYhxbbIntegrationService integrationService, IMapProvider mapper)
    {
        _integrationService = integrationService;
        _mapper = mapper;
    }

    public async Task<VehicleLicenseResponseDto> Handle(VehicleLicenseQuery request, CancellationToken cancellationToken)
    {
        var integrationDto =
           await _integrationService.GetVehicleLicenseInfoAsync(new VehicleLicenseRequest
           {
               TexPassportSery = request.TexPassportSery,
               TexPassportNumber = request.TexPassportNumber,
               PlateNumber = request.PlateNumber,
               RequestId = Guid.NewGuid().ToString()
           });

        return _mapper
            .Map<VehicleLicenseResponse, VehicleLicenseResponseDto>(integrationDto);
    }
}

