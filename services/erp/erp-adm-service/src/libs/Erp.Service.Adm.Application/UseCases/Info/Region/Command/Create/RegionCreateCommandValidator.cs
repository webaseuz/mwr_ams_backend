using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RegionCreateCommandValidator : AbstractValidator<RegionCreateCommand>
{
    public RegionCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(RegionCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(RegionCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(RegionCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(RegionCreateCommand.FullName)} max length is 250");
    }
}
