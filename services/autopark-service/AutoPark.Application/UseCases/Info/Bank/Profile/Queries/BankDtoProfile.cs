using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Banks;

public class BankDtoProfile :
    Profile
{
    public BankDtoProfile()
    {
        int lang = default;

        //BankDto
        CreateMap<Bank, BankDto>()
         .ForMember(src => src.ShortName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(BankTranslate.GetExpr(TranslateColumn.short_name, lang)).TranslateText ?? ent.ShortName))
         .ForMember(src => src.FullName, conf => conf.MapFrom(ent => ent.Translates.AsQueryable().FirstOrDefault(BankTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.FullName))
         .ForMember(src => src.StateName, conf => conf.MapFrom(ent => ent.State.Translates.AsQueryable().FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.State.FullName));
    }
}
