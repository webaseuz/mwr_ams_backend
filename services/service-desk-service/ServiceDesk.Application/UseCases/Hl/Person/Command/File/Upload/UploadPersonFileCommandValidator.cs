using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Persons;

public class UploadPersonFileCommandValidator :
    AbstractValidator<UploadPersonFileCommand>
{
    public UploadPersonFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadPersonFileCommand.Files)));
    }
}
