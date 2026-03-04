using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class MobileAppVersionUpdateCommandValidator : AbstractValidator<MobileAppVersionUpdateCommand>
{
    public MobileAppVersionUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.Id)} is required");
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.FileName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.FileName)} max length is 250");
        RuleFor(x => x.VersionCode)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.VersionCode)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.VersionCode)} max length is 250");
        RuleFor(x => x.Details)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.Details)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionUpdateCommand.Details)} max length is 250");
    }
}
