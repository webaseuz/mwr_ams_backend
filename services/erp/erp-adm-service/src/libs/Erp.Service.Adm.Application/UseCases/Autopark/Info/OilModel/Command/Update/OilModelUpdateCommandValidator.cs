using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OilModelUpdateCommandValidator : AbstractValidator<OilModelUpdateCommand>
{
    public OilModelUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(OilModelUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(OilModelUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilModelUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(OilModelUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilModelUpdateCommand.FullName)} max length is 250");
    }
}
