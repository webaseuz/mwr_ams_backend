using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class OilModelCreateCommandValidator : AbstractValidator<OilModelCreateCommand>
{
    public OilModelCreateCommandValidator()
    {
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(OilModelCreateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilModelCreateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(OilModelCreateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(OilModelCreateCommand.FullName)} max length is 250");
    }
}
