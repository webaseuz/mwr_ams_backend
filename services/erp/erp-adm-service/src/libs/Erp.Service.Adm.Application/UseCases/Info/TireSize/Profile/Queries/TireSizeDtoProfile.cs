using Erp.Core.Service.Application;
using AutoMapper;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class TireSizeDtoProfile : CultureProfile
{
    public TireSizeDtoProfile()
    {
        var cultureId = 1;

        //TireSizeDto
        CreateMap<TireSize, TireSizeDto>()
             .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable()
             .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.State.FullName))
             .ForMember(src => src.Size, conf => conf.MapFrom(ent => $"{ent.Height}/{ent.Width} R{ent.Radius}".Replace(".00", "")));
    }
}
