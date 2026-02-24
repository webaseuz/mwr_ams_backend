using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TransportModels;

public class TransportModelFuelDtoProfile : Profile
{
    public TransportModelFuelDtoProfile()
    {
        int lang = default;

        CreateMap<TransportModelFuel, TransportModelFuelDto>()
            .ForMember(src => src.FuelTypeName, conf => conf.MapFrom(ent => ent.FuelType.Translates.AsQueryable().FirstOrDefault(FuelTypeTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.FuelType.ShortName));
    }
}
