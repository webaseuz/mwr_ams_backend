using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseTireDtoProfile : Profile
{
    public ExpenseTireDtoProfile()
    {
        int lang = default;

        CreateMap<ExpenseTire, ExpenseTireDto>()
            .ForMember(src => src.TireModelName, conf => conf.MapFrom(ent => ent.TireModel.Translates.AsQueryable()
                .FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.TireModel.ShortName))
            .ForMember(src => src.TireModelName, conf => conf.MapFrom(ent => ent.TireModel.Translates.AsQueryable()
                .FirstOrDefault(TireModelTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.TireModel.ShortName))
            .ForMember(src => src.TireSizeName, conf => conf.MapFrom(ent => $"{ent.TireSize.Height}/{ent.TireSize.Width} R{ent.TireSize.Radius}"))
            .ForMember(src => src.Files, conf => conf.MapFrom(ent => ent.Files))
            ;

    }
}
