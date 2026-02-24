using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TireSizes;

public class TireSizeDtoProfile : Profile
{
    public TireSizeDtoProfile()
    {
        int lang = default;

        //TireSizeDto
        CreateMap<TireSize, TireSizeDto>()
             .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
             .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
             .ForMember(src => src.Size, conf => conf.MapFrom(ent => $"{ent.Height}/{ent.Width} R{ent.Radius}".Replace(".00", "")));
    }
}
