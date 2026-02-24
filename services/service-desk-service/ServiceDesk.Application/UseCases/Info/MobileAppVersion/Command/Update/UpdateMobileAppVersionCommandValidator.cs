using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class UpdateMobileAppVersionCommandValidator :
    AbstractValidator<UpdateMobileAppVersionCommand>
{
    public UpdateMobileAppVersionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateMobileAppVersionCommand.Id)));

        RuleFor(x => x.VersionCode)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateMobileAppVersionCommand.VersionCode)));

        RuleFor(x => x.Details)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateMobileAppVersionCommand.Details)));

        RuleFor(x => x.FileName)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(UpdateMobileAppVersionCommand.FileName)));
    }
}
