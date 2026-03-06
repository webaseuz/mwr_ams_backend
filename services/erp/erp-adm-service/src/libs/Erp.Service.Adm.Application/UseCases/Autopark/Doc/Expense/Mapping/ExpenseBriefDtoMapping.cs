using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class ExpenseBriefDtoMapping : CultureProfile
{
    public ExpenseBriefDtoMapping()
    {
        var cultureId = 1;

        CreateMap<Expense, ExpenseBriefDto>()
            .ForMember(x => x.TransportInfo, x => x.MapFrom(ent =>
                $"{ent.Transport.StateCode} {ent.Transport.StateNumber}"))
            .ForMember(x => x.DriverName, x => x.MapFrom(ent => ent.Driver.Person.FullName))
            .ForMember(x => x.BranchName, x => x.MapFrom(ent => ent.Branch.FullName))
            .ForMember(x => x.StatusName, x => x.MapFrom(ent =>
                ent.Status.Translates.AsQueryable()
                    .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId))
                    .TranslateText ?? ent.Status.FullName))
            .ForMember(x => x.CanAccept, x => x.Ignore())
            .ForMember(x => x.CanModify, x => x.Ignore())
            .ForMember(x => x.CanDelete, x => x.Ignore())
            .ForMember(x => x.CanCancel, x => x.Ignore())
            .ForMember(x => x.CanSend, x => x.Ignore())
            .ForMember(x => x.CanRevoke, x => x.Ignore());
    }
}
