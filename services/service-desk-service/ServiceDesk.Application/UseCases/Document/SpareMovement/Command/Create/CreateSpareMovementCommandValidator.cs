using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.SpareMovements;

public class CreateSpareMovementCommandValidator :
    AbstractValidator<CreateSpareMovementCommand>
{
    public CreateSpareMovementCommandValidator()
    {

        RuleFor(x => x.FromBranchId)
            .GreaterThan(0)
            .When(x => x.FromBranchId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateSpareMovementCommand.FromBranchId)));

        RuleFor(x => x.ToBranchId)
            .GreaterThan(0)
            .When(x => x.ToBranchId.HasValue)
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateSpareMovementCommand.ToBranchId)));

        RuleFor(x => x.ToBranchId)
            .NotEqual(x => x.FromBranchId)
            .When(x => x.MovementTypeId == MovementTypeIdConst.MOVEMENT && 
                       x.ToBranchId.HasValue && x.FromBranchId.HasValue)
            .Failure(ClientValidationExceptionHelper.PropertiesMustNotBeEqual("Из филиал", "На филиал"));

        RuleFor(x => x.MovementTypeId)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateSpareMovementCommand.MovementTypeId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementCommand.MovementTypeId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementCommand.MovementTypeId), 0, int.MaxValue));
    }
}
