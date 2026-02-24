using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class UpdateSpareMovementCommandValidator :
    AbstractValidator<UpdateSpareMovementCommand>
{
    public UpdateSpareMovementCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementCommand.Id)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementCommand.Id), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementCommand.Id), 0, int.MaxValue));

        RuleFor(x => x.FromBranchId)
            .GreaterThan(0)
            .When(x => x.FromBranchId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementCommand.FromBranchId)));

        RuleFor(x => x.ToBranchId)
            .GreaterThan(0)
            .When(x => x.ToBranchId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementCommand.ToBranchId)));

        RuleFor(x => x.MovementTypeId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementCommand.MovementTypeId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementCommand.MovementTypeId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementCommand.MovementTypeId), 0, int.MaxValue));

    }
}
