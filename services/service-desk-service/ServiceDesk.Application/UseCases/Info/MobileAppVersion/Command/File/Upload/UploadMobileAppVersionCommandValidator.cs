using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UploadMobileAppVersionCommandValidator :
    AbstractValidator<UploadMobileAppVersionCommand>
{
    public UploadMobileAppVersionCommandValidator()
    {
        RuleFor(x => x.Files)
            .NotEmpty()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UploadMobileAppVersionCommand.Files)));
    }
}
