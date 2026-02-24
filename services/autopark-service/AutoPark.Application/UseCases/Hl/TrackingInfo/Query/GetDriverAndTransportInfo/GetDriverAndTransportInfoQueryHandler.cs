using AutoMapper;
using AutoPark.Application.UseCases.PresentTrackingInfos;
using AutoPark.Domain;
using AutoPark.Domain.Constants;
using Bms.Core.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoPark.Application.UseCases.TrackingInfos;

public class GetDriverAndTransportInfoQueryHandler :
    IRequestHandler<GetDriverAndTransportInfoQuery, DriverAndTransportInfoDto>
{
    private readonly IReadEfCoreContext _context;
    private readonly IMapper _mapper;

    public GetDriverAndTransportInfoQueryHandler(
        IReadEfCoreContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DriverAndTransportInfoDto> Handle(
        GetDriverAndTransportInfoQuery request,
        CancellationToken cancellationToken)
    {
        var person = await GetPersonWithDetailsAsync(request.PersonId, cancellationToken);
        ValidatePersonExists(person, request.PersonId);


        var transport = await GetTransportForPersonAsync(person, cancellationToken);
        var dto = MapToDto(person, transport);

        return dto;
    }

    private async Task<Person> GetPersonWithDetailsAsync(long personId, CancellationToken cancellationToken)
    {
        return await _context.People
            .Include(p => p.Branch)
            .Include(p => p.Drivers)
                .ThenInclude(d => d.Branch)
            .FirstOrDefaultAsync(p => p.Id == personId, cancellationToken);
    }

    private async Task<Transport> GetTransportForPersonAsync(Person person, CancellationToken cancellationToken)
    {
        var driver = person.Drivers.FirstOrDefault();
        if (driver is null) return null;

        return await _context.Transports
            .Where(t => t.Settings.Any(s => s.StatusId == StatusIdConst.ACCEPTED && s.DriverId == driver.Id))
            .Include(t => t.TransportModel)
            .Include(t => t.TransportBrand)
            .Include(t => t.TransportColor)
            .FirstOrDefaultAsync(cancellationToken);
    }

    private DriverAndTransportInfoDto MapToDto(Person person, Transport transport)
    {
        var dto = _mapper.Map<DriverAndTransportInfoDto>(person);

        if (transport is not null)
        {
            _mapper.Map(transport, dto);
        }

        dto.BranchName = GetBranchName(person);
        return dto;
    }

    private static string GetBranchName(Person person)
    {
        var driverBranch = person.Drivers.FirstOrDefault()?.Branch;
        var personBranch = person.Branch;

        return driverBranch?.ShortName
            ?? driverBranch?.FullName
            ?? personBranch?.ShortName
            ?? personBranch?.FullName
            ?? string.Empty;
    }

    private static void ValidatePersonExists(Person person, long personId)
    {
        if (person is null)
        {
            throw ClientLogicalExceptionHelper.NotFound(personId);
        }
    }
}