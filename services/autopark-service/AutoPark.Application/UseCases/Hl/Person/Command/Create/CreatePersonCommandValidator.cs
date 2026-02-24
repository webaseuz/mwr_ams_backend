using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Persons;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Pinfl)
            .Matches(@"^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.Pinfl))
            .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePersonCommand.Pinfl)).Message);

        RuleFor(x => x.Inn)
            .Matches(@"^\d{9}$|^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.Inn))
            .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePersonCommand.Inn)).Message);

        //RuleFor(x => x.DocumentSeria)
        //    .Matches(@"^[A-Z]{2}$")
        //    .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePersonCommand.DocumentSeria)).Message);

        //RuleFor(x => x.DocumentNumber)
        //    .Matches(@"^\d{7}$")
        //    .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreatePersonCommand.DocumentNumber)).Message);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ClientValidationExceptionHelper.NotNullPropert(nameof(CreatePersonCommand.LastName)).Message)
            .MaximumLength(250)
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreatePersonCommand.LastName), 1, 250).Message);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ClientValidationExceptionHelper.NotNullPropert(nameof(CreatePersonCommand.FirstName)).Message)
            .MaximumLength(250)
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreatePersonCommand.FirstName), 1, 250).Message);

        RuleFor(x => x.MiddleName)
            .MaximumLength(250)
            .When(x => !string.IsNullOrEmpty(x.MiddleName))
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreatePersonCommand.MiddleName), 1, 250).Message);
    }
}
