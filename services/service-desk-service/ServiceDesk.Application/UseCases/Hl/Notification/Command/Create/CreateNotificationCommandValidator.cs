using FluentValidation;

namespace ServiceDesk.Application.UseCases.Notifications;

public class CreateNotificationCommandValidator :
    AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        
    }
}
