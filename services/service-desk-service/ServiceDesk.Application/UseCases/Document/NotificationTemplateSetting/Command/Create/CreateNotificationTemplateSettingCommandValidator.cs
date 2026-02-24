using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.NotificationTemplateSettings;

public class CreateNotificationTemplateSettingCommandValidator :
	AbstractValidator<CreateNotificationTemplateSettingCommand>
{
    public CreateNotificationTemplateSettingCommandValidator()
    {
        RuleFor(x => x.NotificationTemplateId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateNotificationTemplateSettingCommand.NotificationTemplateId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateNotificationTemplateSettingCommand.NotificationTemplateId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateNotificationTemplateSettingCommand.NotificationTemplateId), 0, int.MaxValue));
    }
}
