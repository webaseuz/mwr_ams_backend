using FluentValidation;

namespace AutoPark.Application.UseCases.Notifications;

public class CreateNotificationCommandValidator :
    AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {

    }
}
