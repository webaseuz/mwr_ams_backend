using Erp.Service.Adm.Models;
using FluentValidation;

namespace Erp.Service.Adm.Application.UseCases;

public class TireModelUpdateCommandValidator : AbstractValidator<TireModelUpdateCommand>
{
    public TireModelUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage($"{nameof(TireModelUpdateCommand.Id)} is required");
        RuleFor(x => x.ShortName)
            .NotEmpty()
            .WithMessage($"{nameof(TireModelUpdateCommand.ShortName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TireModelUpdateCommand.ShortName)} max length is 250");
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"{nameof(TireModelUpdateCommand.FullName)} is required")
            .MaximumLength(250)
            .WithMessage($"{nameof(TireModelUpdateCommand.FullName)} max length is 250");
    }
}
