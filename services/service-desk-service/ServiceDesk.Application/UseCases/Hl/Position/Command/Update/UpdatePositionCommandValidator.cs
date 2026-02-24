using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Positions;

public class UpdatePositionCommandValidator :
	AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionCommandValidator()
    {
		RuleFor(x => x.Code)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdatePositionCommand.Code)))
			.MaximumLength(50)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePositionCommand.ShortName), 1, 50));

		RuleFor(x => x.ShortName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdatePositionCommand.ShortName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePositionCommand.ShortName), 1, 250));

		RuleFor(x => x.FullName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdatePositionCommand.FullName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePositionCommand.FullName), 1, 250));
	}
}
