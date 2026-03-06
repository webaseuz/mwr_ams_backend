using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

public class GetPresentTrackingInfoByIdQueryHandler : IRequestHandler<PresentTrackingInfoGetByIdQuery, PresentTrackingInfoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ILocalizationBuilder _localizationBuilder;

    public GetPresentTrackingInfoByIdQueryHandler(
        IApplicationDbContext context,
        ILocalizationBuilder localizationBuilder)
    {
        _context = context;
        _localizationBuilder = localizationBuilder;
    }

    public async Task<PresentTrackingInfoDto> Handle(PresentTrackingInfoGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.PresentTrackingInfos
            .Where(b => b.Id == request.Id)
            .Select(b => new PresentTrackingInfoDto
            {
                PersonId = b.PersonId,
                Latitude = b.Latitude,
                Longitude = b.Longitude
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
