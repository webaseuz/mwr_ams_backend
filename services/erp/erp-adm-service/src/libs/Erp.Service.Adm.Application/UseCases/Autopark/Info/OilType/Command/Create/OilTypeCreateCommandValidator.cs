using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OilTypeCreateCommandValidator : AbstractValidator<OilTypeCreateCommand>
{
    public OilTypeCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(OilTypeCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilTypeCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(OilTypeCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilTypeCreateCommand.FullName)} max length is 250");
    }
}
