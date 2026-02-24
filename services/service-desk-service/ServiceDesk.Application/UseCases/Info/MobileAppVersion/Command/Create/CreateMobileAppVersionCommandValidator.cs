using Bms.Core.Application;
using Bms.Core.Domain;
using FluentValidation;

namespace ServiceDesk.Application.UseCases.MobileAppVersions;

public class CreateMobileAppVersionCommandValidator :
    AbstractValidator<CreateMobileAppVersionCommand>
{
    public CreateMobileAppVersionCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateMobileAppVersionCommand.Id)));

        RuleFor(x => x.VersionCode)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateMobileAppVersionCommand.VersionCode)));

        RuleFor(x => x.Details)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateMobileAppVersionCommand.Details)));

        RuleFor(x => x.FileName)
            .NotNull()
            .Failure(ClientValidationExceptionHelper.NotNullPropert(nameof(CreateMobileAppVersionCommand.FileName)));
    }
}
