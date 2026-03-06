using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class RegionUpdateCommandValidator : AbstractValidator<RegionUpdateCommand>
{
    public RegionUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(RegionUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(RegionUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(RegionUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(RegionUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(RegionUpdateCommand.FullName)} max length is 250");
    }
}
