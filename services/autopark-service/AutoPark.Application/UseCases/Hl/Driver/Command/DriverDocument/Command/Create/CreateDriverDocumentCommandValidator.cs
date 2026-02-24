using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class CreateDriverDocumentCommandValidator :
    AbstractValidator<CreateDriverDocumentCommand>
{
    public CreateDriverDocumentCommandValidator()
    {
        RuleFor(x => x.DocumentNumber)
             .NotEmpty()
             .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDriverDocumentCommand.DocumentNumber)))
             .Length(9)
             .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(CreateDriverDocumentCommand.DocumentNumber), 9, 9))
             .Matches("^[A-Z]{2}\\d{7}$")
             .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(CreateDriverDocumentCommand.DocumentNumber)));

        RuleFor(x => x.DocumentEndOn)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDriverDocumentCommand.DocumentEndOn)));
    }
}
