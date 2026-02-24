using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.Citizenships;

public class CitizenshipDtoProfile :
    Profile
{
    public CitizenshipDtoProfile()
    {
        int lang = default;

        //CitizenshipDto
        CreateMap<Citizenship, CitizenshipDto>()
         .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(CitizenshipTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
         .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(CitizenshipTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}
