using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Drivers;

public class UploadDriverDocumentFileCommandValidator :
    AbstractValidator<UploadDriverDocumentFileCommand>
{
    public UploadDriverDocumentFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadDriverDocumentFileCommand.Files)));
    }
}
