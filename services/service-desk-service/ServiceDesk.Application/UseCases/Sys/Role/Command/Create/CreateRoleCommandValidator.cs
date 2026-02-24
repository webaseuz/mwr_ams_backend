using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Roles;

public class CreateRoleCommandValidator :
	AbstractValidator<CreateRoleCommand>
{
	public CreateRoleCommandValidator()
	{
		RuleFor(x => x.ShortName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRoleCommand.ShortName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRoleCommand.ShortName), 1, 250));

		RuleFor(x => x.FullName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateRoleCommand.FullName)))
			.MaximumLength(500)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateRoleCommand.FullName), 1, 500));
	}
}
