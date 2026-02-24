using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportModels;

public class UploadTransportModelFileCommandValidator :
    AbstractValidator<UploadTransportModelFileCommand>
{
    public UploadTransportModelFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadTransportModelFileCommand.Files)));
    }
}
