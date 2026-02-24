using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.NotificationTemplateSettings;

public class GetNotificationTemplateSettingByIdQueryValidator :
    AbstractValidator<GetNotificationTemplateSettingByIdQuery>
{
    public GetNotificationTemplateSettingByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetNotificationTemplateSettingByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetNotificationTemplateSettingByIdQuery.Id), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetNotificationTemplateSettingByIdQuery.Id), 0, int.MaxValue));
    }
}
