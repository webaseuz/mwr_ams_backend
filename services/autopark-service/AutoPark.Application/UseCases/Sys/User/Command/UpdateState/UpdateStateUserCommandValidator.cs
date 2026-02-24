using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Users;

public class UpdateStateUserCommandValidator :
    AbstractValidator<UpdateStateUserCommand>
{
    public UpdateStateUserCommandValidator()
    {
        RuleFor(x => x.Id)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateStateUserCommand.Id)))
                .GreaterThan(0)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateStateUserCommand.Id), 1, int.MaxValue))
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateStateUserCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.StateId)
                .NotNull()
                .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateStateUserCommand.StateId)))
                .GreaterThan(0)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateStateUserCommand.StateId), 1, int.MaxValue))
                .LessThan(int.MaxValue)
                .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateStateUserCommand.StateId), 1, int.MaxValue));
    }
}