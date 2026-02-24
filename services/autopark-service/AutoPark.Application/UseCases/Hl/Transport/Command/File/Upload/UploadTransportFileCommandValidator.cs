using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.Transports;

public class UploadTransportFileCommandValidator :
    AbstractValidator<UploadTransportFileCommand>
{
    public UploadTransportFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadTransportFileCommand.Files)));
    }
}
