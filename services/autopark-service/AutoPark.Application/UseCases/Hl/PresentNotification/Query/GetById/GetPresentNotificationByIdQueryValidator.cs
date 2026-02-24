using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.PresentNotifications;

public class GetPresentNotificationByIdQueryValidator :
    AbstractValidator<GetPresentNotificationByIdQuery>
{
    public GetPresentNotificationByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(GetPresentNotificationByIdQuery.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPresentNotificationByIdQuery.Id), 1, int.MaxValue))
            .LessThan(long.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(GetPresentNotificationByIdQuery.Id), 1, int.MaxValue));
    }
}
