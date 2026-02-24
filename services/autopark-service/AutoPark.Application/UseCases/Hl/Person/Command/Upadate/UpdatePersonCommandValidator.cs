using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Persons;

public class UpdatePersonCommandValidator :
    AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        //RuleFor(x => x.Id)
        //    .GreaterThan(0)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePersonCommand.Id), 1, int.MaxValue))
        //    .LessThan(int.MaxValue)
        //    .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePersonCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.Pinfl)
            .Matches(@"^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.Pinfl))
            .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdatePersonCommand.Pinfl)).Message);

        RuleFor(x => x.Inn)
            .Matches(@"^\d{9}$|^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.Inn))
            .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdatePersonCommand.Inn)).Message);

        //RuleFor(x => x.DocumentSeria)
        //    .Matches(@"^[A-Z]{2}$")
        //    .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdatePersonCommand.DocumentSeria)).Message);

        //RuleFor(x => x.DocumentNumber)
        //    .Matches(@"^\d{7}$")
        //    .WithMessage(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdatePersonCommand.DocumentNumber)).Message);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(ClientValidationExceptionHelper.NotNullPropert(nameof(CreatePersonCommand.LastName)).Message)
            .MaximumLength(250)
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePersonCommand.LastName), 1, 250).Message);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(ClientValidationExceptionHelper.NotNullPropert(nameof(CreatePersonCommand.FirstName)).Message)
            .MaximumLength(250)
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePersonCommand.FirstName), 1, 250).Message);

        RuleFor(x => x.MiddleName)
            .MaximumLength(250)
            .When(x => !string.IsNullOrEmpty(x.MiddleName))
            .WithMessage(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdatePersonCommand.MiddleName), 1, 250).Message);
    }
}
