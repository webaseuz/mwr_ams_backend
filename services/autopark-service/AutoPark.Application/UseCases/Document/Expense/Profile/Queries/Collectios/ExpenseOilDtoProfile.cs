using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseOilDtoProfile : Profile
{
    public ExpenseOilDtoProfile()
    {

        int lang = default;

        CreateMap<ExpenseOil, ExpenseOilDto>()
            .ForMember(src => src.OilTypeName, conf => conf.MapFrom(ent => ent.OilType.Translates.AsQueryable()
                .FirstOrDefault(OilTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.OilType.FullName))
            .ForMember(src => src.OilModelName, conf => conf.MapFrom(ent => ent.OilModel.Translates.AsQueryable()
                .FirstOrDefault(OilModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.OilType.FullName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files))
            ;
    }
}
