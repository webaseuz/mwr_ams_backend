using AutoMapper;
using Erp.Integration.Models;
using Erp.Integration.Models.Yhxbb.VehicleInfo;
using Erp.Integration.Service;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class VehicleLicenseHandler(
    IYhxbbIntegrationService integrationService,
    IMapper mapper) : IRequestHandler<VehicleLicenseQuery, VehicleLicenseResponseDto>
{
    public async Task<VehicleLicenseResponseDto> Handle(VehicleLicenseQuery request, CancellationToken cancellationToken)
    {
        var integrationDto = await integrationService.GetVehicleLicenseInfoAsync(new VehicleLicenseRequest
        {
            TexPassportSery = request.TexPassportSery,
            TexPassportNumber = request.TexPassportNumber,
            PlateNumber = request.PlateNumber,
            RequestId = Guid.NewGuid().ToString()
        });

        return mapper.Map<VehicleLicenseResponseDto>(integrationDto);
    }
}
