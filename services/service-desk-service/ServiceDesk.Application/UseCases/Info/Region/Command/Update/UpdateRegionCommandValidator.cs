using Bms.Core.Application;
using Bms.Core.Domain;
using Bms.WEBASE.Extensions;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Regions;

public class UpdateRegionCommandValidator :
	AbstractValidator<UpdateRegionCommand>
{
    public UpdateRegionCommandValidator()
    {
		RuleFor(x => x.Id)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.Id), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.Id), 1, int.MaxValue));

		RuleFor(x => x.OrderCode)
			.MinimumLength(3)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.OrderCode), 1, 3));

		RuleFor(x => x.ShortName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRegionCommand.ShortName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.ShortName), 1, 250));

		RuleFor(x => x.FullName)
			.NotEmpty()
			.Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateRegionCommand.FullName)))
			.MaximumLength(250)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.FullName), 1, 250));

		RuleFor(x => x.CountryId)
			.NotNull()
			.GreaterThan(0)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.CountryId), 1, int.MaxValue))
			.LessThan(int.MaxValue)
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.CountryId), 1, int.MaxValue));

		RuleFor(x => x.Code)
			.MaximumLength(50)
			.When(x => !x.Code.IsNullOrEmptyObject())
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.Code), 1, 50));

		RuleFor(x => x.Soato)
				.MaximumLength(50)
				.When(x => !x.Soato.IsNullOrEmptyObject())
				.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.Soato), 1, 50));

		RuleFor(x => x.RoamingCode)
			.MaximumLength(50)
			.When(x => !x.RoamingCode.IsNullOrEmptyObject())
			.Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateRegionCommand.RoamingCode), 1, 50));
	}
}
