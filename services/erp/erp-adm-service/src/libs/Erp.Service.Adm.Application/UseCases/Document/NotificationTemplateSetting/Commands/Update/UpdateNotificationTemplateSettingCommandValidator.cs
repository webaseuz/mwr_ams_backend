using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class UpdateNotificationTemplateSettingCommandValidator :
    AbstractValidator<UpdateNotificationTemplateSettingCommand>
{
    public UpdateNotificationTemplateSettingCommandValidator()
    {
        RuleFor(x => x.NotificationTemplateId)
            .GreaterThan(0)
            .WithMessage($"{nameof(UpdateNotificationTemplateSettingCommand.NotificationTemplateId)} must be greater than 0");
    }
}
