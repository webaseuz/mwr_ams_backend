using AutoMapper;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TransportSettingFuelDtoProfile : CultureProfile
{
    public TransportSettingFuelDtoProfile()
    {
        var cultureId = 1;

        CreateMap<TransportSettingFuel, TransportSettingFuelDto>()
            .ForMember(src => src.FuelTypeName, conf => conf.MapFrom(ent => ent.FuelType.Translates.AsQueryable()
                .FirstOrDefault(FuelTypeTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.FuelType.FullName));
    }
}
