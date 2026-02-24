using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseLiquidDtoProfile : Profile
{
    public ExpenseLiquidDtoProfile()
    {
        int lang = default;

        CreateMap<ExpenseLiquid, ExpenseLiquidDto>()
            .ForMember(src => src.LiquidTypeName, conf => conf.MapFrom(ent => ent.LiquidType.Translates.AsQueryable()
                .FirstOrDefault(LiquidTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.LiquidType.FullName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files));
    }
}
