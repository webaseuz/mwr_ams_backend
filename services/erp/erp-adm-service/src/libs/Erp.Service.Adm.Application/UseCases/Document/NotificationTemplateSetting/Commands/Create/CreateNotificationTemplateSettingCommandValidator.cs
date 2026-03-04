using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class CreateNotificationTemplateSettingCommandValidator :
    AbstractValidator<CreateNotificationTemplateSettingCommand>
{
    public CreateNotificationTemplateSettingCommandValidator()
    {
        RuleFor(x => x.NotificationTemplateId)
            .GreaterThan(0)
            .WithMessage($"{nameof(CreateNotificationTemplateSettingCommand.NotificationTemplateId)} must be greater than 0");
    }
}
