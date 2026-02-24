using AutoMapper;
using ServiceDesk.Domain;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class NotificationTemplateSettingDtoProfile : Profile
{
    public NotificationTemplateSettingDtoProfile()
    {

        int lang = default;

        CreateMap<NotificationTemplateSetting, NotificationTemplateSettingDto>()
			.ForMember(src => src.BranchName, conf => conf.MapFrom(ent => ent.Branch.FullName))
			.ForMember(src => src.NotificationTemplateName, conf => conf.MapFrom(ent => ent.NotificationTemplete.Key))
			.ForMember(src => src.NotificationTemplateMessage, conf => conf.MapFrom(ent => ent.NotificationTemplete.Message))
            .ForMember(src => src.StatusName, conf => conf.MapFrom(ent => ent.Status.Translates.AsQueryable()
            .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name, lang)).TranslateText ?? ent.Status.FullName))
            //.ForMember(src => src.Users, conf => conf.MapFrom(ent => ent.NotificationTemplateSettingUsers))
            //.ForMember(src => src.Roles, conf => conf.MapFrom(ent => ent.NotificationTemplateSettingRoles))
            //.ForMember(src => src.RestrictedUsers, conf => conf.MapFrom(ent => ent.NotificationTemplateSettingRestrictedUsers))
            ;
    }
}
