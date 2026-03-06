using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetTrackingInfoByIdQueryHandler : IRequestHandler<TrackingInfoGetByIdQuery, TrackingInfoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetTrackingInfoByIdQueryHandler(
        IApplicationDbContext context,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<TrackingInfoDto> Handle(TrackingInfoGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.TrackingInfos
            .Where(b => b.Id == request.Id)
            .Select(b => new TrackingInfoDto
            {
                PersonId = b.PersonId,
                PersonName = b.Person.FullName,
                Latitude = b.Latitude,
                Longitude = b.Longitude,
                DateAt = b.DateAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = _localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return dto;
    }
}
