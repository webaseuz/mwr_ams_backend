using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.TireSizes;

public class TireSizeBriefDtoProfile : Profile
{
    public TireSizeBriefDtoProfile()
    {
        int lang = default;

        //TireSizeBriefDto
        CreateMap<TireSize, TireSizeBriefDto>()
               .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
               .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName))
             .ForMember(src => src.Size, conf => conf.MapFrom(ent => $"{ent.Width}/{ent.Height}/ R{ent.Radius}".Replace(".00", "")));
    }
}
