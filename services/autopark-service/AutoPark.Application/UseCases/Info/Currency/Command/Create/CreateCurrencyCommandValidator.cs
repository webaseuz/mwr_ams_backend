using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Currencies;

public class CreateCurrencyCommandValidator :
    AbstractValidator<CreateCurrencyCommand>
{
    public CreateCurrencyCommandValidator()
    {
        RuleFor(x => x.Code)
            .MinimumLength(3)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCurrencyCommand.Code), 1, 3));

        RuleFor(x => x.TextCode)
            .MaximumLength(5)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCurrencyCommand.TextCode), 1, 5));

        RuleFor(x => x.FullName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateCurrencyCommand.FullName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCurrencyCommand.FullName), 1, 250));

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateCurrencyCommand.ShortName)))
            .MaximumLength(250)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateCurrencyCommand.ShortName), 1, 250));
    }
}
