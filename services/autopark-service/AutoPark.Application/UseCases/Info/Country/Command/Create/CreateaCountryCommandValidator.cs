using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Countries;

public class CreateaCountryCommandValidator :
    AbstractValidator<CreateCountryCommand>
{
    public CreateaCountryCommandValidator()
    {
        RuleFor(x => x.Code)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCountryCommand.Code), 1, 5));

        RuleFor(x => x.TextCode)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCountryCommand.TextCode), 1, 5));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateCountryCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCountryCommand.ShortName), 1, 250));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateCountryCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCountryCommand.FullName), 1, 250));
    }
}
