using AutoMapper;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class GetRefuelByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMainAuthService authService,
    ICultureHelper cultureHelper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<RefuelGetByIdQuery, RefuelDto>
{
    public async Task<RefuelDto> Handle(RefuelGetByIdQuery request, CancellationToken cancellationToken)
    {
        var query = context.Refuels.Where(x => x.Id == request.Id);

        var dto = await query.MapTo<RefuelDto>(mapper, cultureHelper).FirstOrDefaultAsync(cancellationToken);

        if (dto is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        dto.CanCreateForAllBranch = authService.HasPermission(nameof(AutoparkPermissionCode.RefuelViewAll));

        return dto;
    }
}
