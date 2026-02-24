using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Refuels;

public class UploadRefuelFileCommandValidator :
    AbstractValidator<UploadRefuelFileCommand>
{
    public UploadRefuelFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadRefuelFileCommand.Files)));
    }
}
