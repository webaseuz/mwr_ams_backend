using AutoPark.Integration.Models;
using AutoPark.Integration.Service;
using Bms.Core.Application.Mapping;
using MediatR;

namespace AutoPark.Application.UseCases;

public class DriverLicenseHandler
    : IRequestHandler<DriverLicenseQuery, DriverLicenseResponseDto>
{
    private readonly IYhxbbIntegrationService _integrationService;
    private readonly IMapProvider _mapper;

    public DriverLicenseHandler(IYhxbbIntegrationService integrationService, IMapProvider mapper)
    {
        _integrationService = integrationService;
        _mapper = mapper;
    }

    public async Task<DriverLicenseResponseDto> Handle(DriverLicenseQuery request, CancellationToken cancellationToken)
    {
        var integrationDto =
           await _integrationService.GetDriverLicenseInfoAsync(new DriverLicenseRequest
           {
               PassportSeries = request.PassportSeries,
               PassportNumber = request.PassportNumber,
               ApplicantPinfl = request.Pinfl,
               RequestId = Guid.NewGuid().ToString()
           });

        return _mapper.Map<
        AutoPark.Integration.Models.DriverLicenseResponse,
        DriverLicenseResponseDto
    >(integrationDto);
    }
}

