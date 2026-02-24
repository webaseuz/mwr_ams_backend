using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseDtoProfile : Profile
{
    public ExpenseDtoProfile()
    {
        int lang = default;

        //ExpenseDto
        CreateMap<Expense, ExpenseDto>()
                 .ForMember(scr => scr.Batteries, conf => conf.MapFrom(ent => ent.Batteries))
                 .ForMember(scr => scr.Inspections, conf => conf.MapFrom(ent => ent.Inspections))
                 .ForMember(scr => scr.Insurances, conf => conf.MapFrom(ent => ent.Insurances))
                 .ForMember(scr => scr.Liquids, conf => conf.MapFrom(ent => ent.Liquids))
                 .ForMember(scr => scr.Oils, conf => conf.MapFrom(ent => ent.Oils))
                 .ForMember(scr => scr.Tires, conf => conf.MapFrom(ent => ent.Tires))
                 .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                 .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
                 .ForMember(src => src.TransportInfo, conf => conf.MapFrom(ent => ent.Transport.TransportModel.FullName))
                 .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FirstName))
                 .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName));
    }
}
