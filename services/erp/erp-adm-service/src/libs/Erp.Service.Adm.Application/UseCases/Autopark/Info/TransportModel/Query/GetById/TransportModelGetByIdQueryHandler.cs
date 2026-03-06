using Erp.Core.Service.Application;
using Erp.Core.Service.Application.Localization;
using Erp.Service.Adm.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WEBASE;

namespace Erp.Service.Adm.Application.UseCases;

internal sealed class TransportModelGetByIdQueryHandler(
    IApplicationDbContext context,
    ILocalizationBuilder localizationBuilder) : IRequestHandler<TransportModelGetByIdQuery, TransportModelDto>
{
    public async Task<TransportModelDto> Handle(TransportModelGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await context.TransportModels
            .Where(x => x.Id == request.Id && x.StateId == WbStateIdConst.ACTIVE)
            .Select(x => new TransportModelDto
            {
                Id = x.Id,
                OrderCode = x.OrderCode,
                ShortName = x.ShortName,
                FullName = x.FullName,
                TransportTypeId = x.TransportTypeId,
                TransportTypeName = x.TransportType.FullName,
                TransportBrandId = x.TransportBrandId,
                TransportBrandName = x.TransportBrand.FullName,
                TransmissionBoxTypeId = x.TransmissionBoxTypeId,
                TransmissionBoxTypeName = x.TransmissionBoxType.FullName,
                LoadCapacity = x.LoadCapacity,
                SeatCount = x.SeatCount,
                ConsumptionPer100Km = x.ConsumptionPer100Km,
                ConsumptionPerHour = x.ConsumptionPerHour,
                StateId = x.StateId,
                CreatedAt = x.CreatedAt,
                LastModifiedAt = x.LastModifiedAt,
                Translates = x.Translates.Select(t => new TransportModelTranslateDto
                {
                    ColumnName = t.ColumnName.ToString(),
                    LanguageId = t.LanguageId,
                    TranslateText = t.TranslateText
                }).ToList(),
                Files = x.Files.Where(f => !f.IsDeleted).Select(f => new TransportModelFileDto
                {
                    Id = f.Id,
                    FileName = f.FileName,
                    TransportColorId = f.TransportColorId,
                    TransportColorName = f.TransportColor.FullName
                }).ToList(),
                Fuels = x.Fuels.Where(f => !f.IsDeleted).Select(f => new TransportModelFuelDto
                {
                    Id = f.Id,
                    FuelTypeId = f.FuelTypeId,
                    FuelTypeName = f.FuelType.FullName,
                    TankVolume = f.TankVolume
                }).ToList(),
                Liquids = x.Liquids.Where(l => !l.IsDeleted).Select(l => new TransportModelLiquidDto
                {
                    Id = l.Id,
                    LiquidTypeId = l.LiquidTypeId,
                    LiquidTypeName = l.LiquidType.FullName,
                    TankVolume = l.TankVolume
                }).ToList(),
                Oils = x.Oils.Where(o => !o.IsDeleted).Select(o => new TransportModelOilDto
                {
                    Id = o.Id,
                    OilTypeId = o.OilTypeId,
                    OilTypeName = o.OilType.FullName,
                    OilModelId = o.OilModelId,
                    OilModelName = o.OilModel != null ? o.OilModel.FullName : null,
                    TankVolume = o.TankVolume
                }).ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new WbClientException()
                .WithVisibility(WbExceptionVisibility.CLIENT_VISIBLE)
                .WithErrors(new WbFailure
                {
                    Key = "DOCUMENT_NOT_FOUND",
                    ErrorMessage = localizationBuilder.For("DOCUMENT_NOT_FOUND").WithData(new { Id = request.Id }).ToString()
                });

        return entity;
    }
}
