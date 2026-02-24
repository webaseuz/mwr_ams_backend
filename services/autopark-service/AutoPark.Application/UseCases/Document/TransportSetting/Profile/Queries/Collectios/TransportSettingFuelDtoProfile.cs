using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportSettings;

public class TransportSettingFuelDtoProfile : Profile
{
    public TransportSettingFuelDtoProfile()
    {
        int lang = default;

        CreateMap<TransportSettingFuel, TransportSettingFuelDto>()
            .ForMember(src => src.FuelTypeName, conf => conf.MapFrom(ent => ent.FuelType.Translates.AsQueryable()
                .FirstOrDefault(FuelTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FuelType.FullName));

        ;
    }
}
