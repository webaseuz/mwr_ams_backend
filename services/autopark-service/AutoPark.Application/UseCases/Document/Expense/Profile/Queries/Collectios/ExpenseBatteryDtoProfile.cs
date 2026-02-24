using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseBatteryDtoProfile : Profile
{
    public ExpenseBatteryDtoProfile()
    {
        int lang = default;

        CreateMap<ExpenseBattery, ExpenseBatteryDto>()
            .ForMember(src => src.BatteryTypeName, conf => conf.MapFrom(ent => ent.BatteryType.Translates.AsQueryable()
                .FirstOrDefault(BatteryTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.BatteryType.FullName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files));
    }
}
