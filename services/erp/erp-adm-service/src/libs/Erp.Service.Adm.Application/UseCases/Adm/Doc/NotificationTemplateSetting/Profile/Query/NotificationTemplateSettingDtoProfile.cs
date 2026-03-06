using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationTemplateSettingDtoProfile : CultureProfile
{
    public NotificationTemplateSettingDtoProfile()
    {
        var cultureId = 1;

        CreateMap<NotificationTemplateSetting, NotificationTemplateSettingDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.NotificationTemplateName, conf => conf.MapFrom(ent => ent.NotificationTemplete.Key))
            .ForMember(src => src.NotificationTemplateMessage, conf => conf.MapFrom(ent => ent.NotificationTemplete.Message))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.CanCreateForAllBranch, conf => conf.Ignore())
            ;
    }
}
