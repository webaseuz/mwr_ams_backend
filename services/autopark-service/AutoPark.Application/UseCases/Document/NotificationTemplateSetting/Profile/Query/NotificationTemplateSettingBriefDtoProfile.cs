using AutoMapper;
using AutoPark.Domain;
using Bms.Core.Domain;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingBriefDtoProfile : Profile
{
    public NotificationTemplateSettingBriefDtoProfile()
    {
        int lang = default;

        CreateMap<NotificationTemplateSetting, NotificationTemplateSettingBriefDto>()
            .ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
            .ForMember(src => src.NotificationTemplateName, conf => conf.MapFrom(ent => ent.NotificationTemplete.Key))
            .ForMember(src => src.NotificationTemplateMessage, conf => conf.MapFrom(ent => ent.NotificationTemplete.Message))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable().FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName));
    }
}
