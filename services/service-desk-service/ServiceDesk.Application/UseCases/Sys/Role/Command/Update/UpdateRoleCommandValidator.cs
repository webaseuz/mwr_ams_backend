using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Roles;

public class UpdateRoleCommandValidator :
	AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
		RuleFor(x => x.Id)
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRoleCommand.Id), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRoleCommand.Id), 1, int.MaxValue));

		RuleFor(x => x.ShortName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRoleCommand.ShortName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRoleCommand.ShortName), 1, 250));

		RuleFor(x => x.FullName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRoleCommand.FullName)))
			.MaximumLength(500)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRoleCommand.FullName), 1, 500));
	}
}
