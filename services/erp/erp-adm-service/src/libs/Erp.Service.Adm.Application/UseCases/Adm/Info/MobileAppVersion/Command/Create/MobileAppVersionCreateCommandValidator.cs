using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class MobileAppVersionCreateCommandValidator : AbstractValidator<MobileAppVersionCreateCommand>
{
    public MobileAppVersionCreateCommandValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.FileName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.FileName)} max length is 250");
        RuleFor(x => x.VersionCode)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.VersionCode)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.VersionCode)} max length is 250");
        RuleFor(x => x.Details)
            .NotEmpty()
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.Details)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(MobileAppVersionCreateCommand.Details)} max length is 250");
    }
}
