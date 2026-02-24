using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.Expenses;

public class ExpenseBriefDtoProfile : Profile
{
    public ExpenseBriefDtoProfile()
    {
        int lang = default;

        CreateMap<Expense, ExpenseBriefDto>()
                 .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                 .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
                 .ForMember(src => src.TransportInfo, conf => conf.MapFrom(ent => $"{ent.Transport.StateCode} {ent.Transport.StateNumber} ({ent.Transport.TransportModel.Translates.AsQueryable()
                 .FirstOrDefault(TransportModelTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Transport.TransportModel.FullName})"))
                 .ForMember(src => src.DriverName, conf => conf.MapFrom(ent => ent.Driver.Person.FirstName))
                 .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.ShortName));

    }
}
