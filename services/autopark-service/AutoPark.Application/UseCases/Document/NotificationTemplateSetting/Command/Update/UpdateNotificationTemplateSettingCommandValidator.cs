using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class UpdateNotificationTemplateSettingCommandValidator :
    AbstractValidator<UpdateNotificationTemplateSettingCommand>
{
    public UpdateNotificationTemplateSettingCommandValidator()
    {
        RuleFor(x => x.NotificationTemplateId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateNotificationTemplateSettingCommand.NotificationTemplateId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNotificationTemplateSettingCommand.NotificationTemplateId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateNotificationTemplateSettingCommand.NotificationTemplateId), 0, int.MaxValue));
    }
}
