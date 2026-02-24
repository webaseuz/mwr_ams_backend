using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.ServiceApplications;

public class UploadServiceApplicationFileCommandValidator : 
    AbstractValidator<UploadServiceApplicationFileCommand>
{
	public UploadServiceApplicationFileCommandValidator()
	{
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadServiceApplicationFileCommand.Files)));
    }
}
