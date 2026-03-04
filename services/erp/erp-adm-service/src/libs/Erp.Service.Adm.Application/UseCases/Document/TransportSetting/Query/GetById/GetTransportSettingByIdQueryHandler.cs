using AutoMapper;
using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetTransportSettingByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ICultureHelper cultureHelper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<TransportSettingGetByIdQuery, TransportSettingDto>
{
    public async Task<TransportSettingDto> Handle(TransportSettingGetByIdQuery request, CancellationToken cancellationToken)
    {
        var query = context.TransportSettings.Where(b => b.Id == request.Id);

        var dto = await query.MapTo<TransportSettingDto>(mapper, cultureHelper)
            .FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        var fuelCard = await context.FuelCards
            .FirstOrDefaultAsync(x => x.TransportId == dto.TransportId, cancellationToken);

        dto.FuelCardNumber = fuelCard?.CardNumber ?? string.Empty;
        dto.CanCreateForAllBranch = authService.HasPermission(nameof(PermissionCode.TransportSettingViewAll));

        return dto;
    }
}
