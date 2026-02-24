using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class UpdateDriverDocumentCommandValidator :
    AbstractValidator<UpdateDriverDocumentCommand>
{
    public UpdateDriverDocumentCommandValidator()
    {
        RuleFor(x => x.Id)
           .GreaterThan(0)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDriverDocumentCommand.Id), 1, int.MaxValue))
           .LessThan(int.MaxValue)
           .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDriverDocumentCommand.Id), 1, int.MaxValue));

        RuleFor(x => x.DocumentNumber)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateDriverDocumentCommand.DocumentNumber)))
            .Length(9)
            .Failure(ClientValidationExceptionHelper.InvalidLengthProperty(nameof(UpdateDriverDocumentCommand.DocumentNumber), 9, 9))
            .Matches("^[A-Z]{2}\\d{7}$")
            .Failure(ClientValidationExceptionHelper.InvalidPropertyFormat(nameof(UpdateDriverDocumentCommand.DocumentNumber)));

        RuleFor(x => x.DocumentEndOn)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateDriverDocumentCommand.DocumentEndOn)));

    }
}
