using Erp.Core;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;

namespace Erp.Service.Adm.Application.UseCases;

public class NotificationTemplateSettingBriefDtoProfile : CultureProfile
{
    public NotificationTemplateSettingBriefDtoProfile()
    {
        var cultureId = 1;

        CreateMap<NotificationTemplateSetting, NotificationTemplateSettingBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.NotificationTemplateName, conf => conf.MapFrom(ent => ent.NotificationTemplete.Key))
            .ForMember(src => src.NotificationTemplateMessage, conf => conf.MapFrom(ent => ent.NotificationTemplete.Message))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, cultureId)).TranslateText ?? ent.Status.FullName))
            .ForMember(src => src.CanAccept, conf => conf.Ignore())
            .ForMember(src => src.CanCancel, conf => conf.Ignore())
            .ForMember(src => src.CanDelete, conf => conf.Ignore())
            .ForMember(src => src.CanModify, conf => conf.Ignore());
    }
}
