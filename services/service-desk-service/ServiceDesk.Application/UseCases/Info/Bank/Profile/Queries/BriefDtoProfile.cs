using AutoMapper;
using Bms.Core.Domain;
using ServiceDesk.Domain;

namespace ServiceDesk.Application.UseCases.Banks;

public class BriefDtoProfile : Profile
{
    public BriefDtoProfile()
    {
        int lang = default;

        //BankBriefDto
        CreateMap<Bank, BankBriefDto>()
            .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(BankTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
            .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(BankTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
            .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}
