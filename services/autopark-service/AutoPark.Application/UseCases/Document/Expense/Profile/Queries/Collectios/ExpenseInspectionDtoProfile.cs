using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseInspectionDtoProfile : Profile
{
    public ExpenseInspectionDtoProfile()
    {
        int lang = default;

        CreateMap<ExpenseInspection, ExpenseInspectionDto>()
             .ForMember(src => src.InspectionTypeName, conf => conf.MapFrom(ent => ent.InspectionType.Translates.AsQueryable()
                .FirstOrDefault(InspectionTypeTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.InspectionType.FullName))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files));
    }
}
