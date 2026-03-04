using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE.AppError;
using WEBASE.i18n;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class DriverPenaltyGetByIdQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    ICultureHelper cultureHelper,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<DriverPenaltyGetByIdQuery, DriverPenaltyDto>
{
    public async Task<DriverPenaltyDto> Handle(DriverPenaltyGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.DriverPenalties
            .Where(dp => dp.Id == request.Id)
            .MapTo<DriverPenaltyDto>(mapper, cultureHelper)
            .FirstOrDefaultAsync(cancellationToken);

        if (result is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return result;
    }
}
