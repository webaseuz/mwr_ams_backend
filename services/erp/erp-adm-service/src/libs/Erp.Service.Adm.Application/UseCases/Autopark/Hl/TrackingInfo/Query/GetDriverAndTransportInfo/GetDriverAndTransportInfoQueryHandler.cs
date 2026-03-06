using AutoMapper;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetDriverAndTransportInfoQueryHandler : IRequestHandler<TrackingInfoGetDriverAndTransportInfoQuery, DriverAndTransportInfoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetDriverAndTransportInfoQueryHandler(
        IApplicationDbContext context,
        IMapper mapper,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _mapper = mapper;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<DriverAndTransportInfoDto> Handle(
        TrackingInfoGetDriverAndTransportInfoQuery request,
        CancellationToken cancellationToken)
    {
        var person = await _context.People
            .Include(p => p.Branch)
            .Include(p => p.Drivers)
                .ThenInclude(d => d.Branch)
            .FirstOrDefaultAsync(p => p.Id == request.PersonId, cancellationToken);

        if (person is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.PersonId }).ToString()
                });

        var driver = person.Drivers.FirstOrDefault();
        Transport? transport = null;

        if (driver is not null)
        {
            transport = await _context.Transports
                .Where(t => t.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED && s.DriverId == driver.Id))
                .Include(t => t.TransportModel)
                .Include(t => t.TransportBrand)
                .Include(t => t.TransportColor)
                .FirstOrDefaultAsync(cancellationToken);
        }

        var dto = _mapper.Map<DriverAndTransportInfoDto>(person);

        if (transport is not null)
            _mapper.Map(transport, dto);

        var driverBranch = person.Drivers.FirstOrDefault()?.Branch;
        var personBranch = person.Branch;

        dto.BranchName = driverBranch?.ShortName
            ?? driverBranch?.FullName
            ?? personBranch?.ShortName
            ?? personBranch?.FullName
            ?? string.Empty;

        return dto;
    }
}
