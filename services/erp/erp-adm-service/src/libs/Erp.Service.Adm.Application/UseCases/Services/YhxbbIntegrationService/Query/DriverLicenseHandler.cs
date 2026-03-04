using AutoMapper;
using Erp.Integration.Models;
using Erp.Integration.Service;
using MediatR;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DriverLicenseHandler(
    IYhxbbIntegrationService integrationService,
    IMapper mapper) : IRequestHandler<DriverLicenseQuery, DriverLicenseResponseDto>
{
    public async Task<DriverLicenseResponseDto> Handle(DriverLicenseQuery request, CancellationToken cancellationToken)
    {
        var integrationDto = await integrationService.GetDriverLicenseInfoAsync(new DriverLicenseRequest
        {
            PassportSeries = request.PassportSeries,
            PassportNumber = request.PassportNumber,
            ApplicantPinfl = request.Pinfl,
            RequestId = Guid.NewGuid().ToString()
        });

        return mapper.Map<DriverLicenseResponseDto>(integrationDto);
    }
}
