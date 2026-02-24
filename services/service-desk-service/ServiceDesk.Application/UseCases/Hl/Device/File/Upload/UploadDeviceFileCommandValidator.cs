using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.Devices;

public class UploadDeviceFileCommandValidator : 
    AbstractValidator<UploadDeviceFileCommand>
{
	public UploadDeviceFileCommandValidator()
	{
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadDeviceFileCommand.Files)));
    }
}
