using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class DeleteSpareMovementCommandValidator :
    AbstractValidator<DeleteSpareMovementCommand>
{
    public DeleteSpareMovementCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(DeleteSpareMovementCommand.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(DeleteSpareMovementCommand.Id), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(DeleteSpareMovementCommand.Id), 0, int.MaxValue));
    }
}
