using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.SpareMovements;
public class UpdateSpareMovementTableCommandValidator :
	AbstractValidator<UpdateSpareMovementTableCommand>
{
    public UpdateSpareMovementTableCommandValidator()
    {
        RuleFor(x => x.DeviceSpareTypeId)
            .NotNull()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementTableCommand.DeviceSpareTypeId)))
            .GreaterThan(0)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementTableCommand.DeviceSpareTypeId), 0, int.MaxValue))
            .LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementTableCommand.DeviceSpareTypeId), 0, int.MaxValue));

		RuleFor(x => x.Quantity)
			.NotNull()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateSpareMovementTableCommand.Quantity)))
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementTableCommand.Quantity), 0, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateSpareMovementTableCommand.Quantity), 0, int.MaxValue));
	}
}
