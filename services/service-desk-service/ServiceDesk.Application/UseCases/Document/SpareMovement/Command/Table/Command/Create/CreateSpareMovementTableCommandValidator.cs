using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.SpareMovements;
public class CreateSpareMovementTableCommandValidator :
	AbstractValidator<CreateSpareMovementTableCommand>
{
    public CreateSpareMovementTableCommandValidator()
    {
        RuleFor(x => x.DeviceSpareTypeId)
            .NotNull()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateSpareMovementTableCommand.DeviceSpareTypeId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementTableCommand.DeviceSpareTypeId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementTableCommand.DeviceSpareTypeId), 0, int.MaxValue));

		RuleFor(x => x.Quantity)
			.NotNull()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateSpareMovementTableCommand.Quantity)))
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementTableCommand.Quantity), 0, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateSpareMovementTableCommand.Quantity), 0, int.MaxValue));
	}
}
