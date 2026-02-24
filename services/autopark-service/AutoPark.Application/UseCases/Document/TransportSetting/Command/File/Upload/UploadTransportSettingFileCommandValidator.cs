using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace AutoPark.Application.UseCases.TransportSettings;

public class UploadTransportSettingFileCommandValidator :
    AbstractValidator<UploadTransportSettingFileCommand>
{
    public UploadTransportSettingFileCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadTransportSettingFileCommand.Files)));
    }
}
